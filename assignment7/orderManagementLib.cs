using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Homework1
{
    // 订单明细类
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }  // 新增主键

        // 外键，指向所属订单
        public int OrderId { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        // 计算属性，不需要映射到数据库中
        [NotMapped]
        public double TotalPrice => Quantity * UnitPrice;

        // 导航属性
        public virtual Order Order { get; set; }

        public OrderDetails()
        {
        }

        public OrderDetails(string productName, int quantity, double unitPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // 重写 Equals 和 GetHashCode 可根据需要保留
        public override bool Equals(object obj)
        {
            if (obj is OrderDetails other)
            {
                return ProductName == other.ProductName &&
                       Quantity == other.Quantity &&
                       Math.Abs(UnitPrice - other.UnitPrice) < 0.001;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Quantity, UnitPrice);
        }

        public override string ToString()
        {
            return $"商品：{ProductName}, 数量：{Quantity}, 单价：{UnitPrice}, 总价：{TotalPrice}";
        }
    }

    // 订单类
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Customer { get; set; }

        // 导航属性，表示一个订单包含多个订单明细
        public virtual List<OrderDetails> OrderDetailsList { get; set; } = new List<OrderDetails>();

        // 计算属性，不映射到数据库中
        [NotMapped]
        public double TotalAmount => OrderDetailsList.Sum(od => od.UnitPrice * od.Quantity);

        public Order()
        {
        }

        public Order(int orderId, string customer)
        {
            OrderId = orderId;
            Customer = customer;
        }

        // 添加订单明细，若存在重复明细则抛出异常
        public void AddOrderDetails(OrderDetails details)
        {
            if (OrderDetailsList.Any(od => od.Equals(details)))
            {
                throw new ApplicationException("订单明细已存在，不能重复添加！");
            }
            OrderDetailsList.Add(details);
        }

        public override bool Equals(object obj)
        {
            if (obj is Order other)
            {
                return OrderId == other.OrderId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }

        public override string ToString()
        {
            string details = string.Join("\n\t", OrderDetailsList.Select(d => d.ToString()));
            return $"订单号：{OrderId}, 客户：{Customer}, 总金额：{TotalAmount}\n\t订单明细：\n\t{details}";
        }
    }
    // 订单服务类
    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        // 添加订单（若已存在则不添加）
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException("订单已存在，不能重复添加！");
            }
            orders.Add(order);
        }

        // 删除订单（如果找不到订单则抛出异常）
        public void DeleteOrder(int orderId)
        {
            Order order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new ApplicationException("删除失败，订单不存在！");
            }
            orders.Remove(order);
        }

        // 修改订单（通过 orderId 定位订单，修改客户名称或订单明细）
        public void UpdateOrder(Order updatedOrder)
        {
            int index = orders.FindIndex(o => o.OrderId == updatedOrder.OrderId);
            if (index < 0)
            {
                throw new ApplicationException("修改失败，订单不存在！");
            }
            orders[index] = updatedOrder;
        }

        // 根据订单号查询
        public List<Order> QueryByOrderId(int orderId)
        {
            var query = orders.Where(o => o.OrderId == orderId)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 根据客户查询
        public List<Order> QueryByCustomer(string customer)
        {
            var query = orders.Where(o => o.Customer == customer)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 根据商品名称查询
        public List<Order> QueryByProductName(string productName)
        {
            var query = orders.Where(o => o.OrderDetailsList.Any(od => od.ProductName == productName))
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 根据订单金额查询（查询订单总金额大于某一值的订单）
        public List<Order> QueryByTotalAmount(double amount)
        {
            var query = orders.Where(o => o.TotalAmount > amount)
                              .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        // 默认按订单号排序，也可传入自定义的排序Lambda表达式
        public List<Order> SortOrders(Func<Order, object> keySelector = null)
        {
            if (keySelector == null)
            {
                return orders.OrderBy(o => o.OrderId).ToList();
            }
            else
            {
                return orders.OrderBy(keySelector).ToList();
            }
        }

        // 获取所有订单
        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }
 
}

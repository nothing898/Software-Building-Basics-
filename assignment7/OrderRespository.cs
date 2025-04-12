using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Homework1
{
    public class OrderRepository
    {
        // 增加订单
        public void AddOrder(Order order)
        {
            using (var context = new OrderDbContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        // 删除指定订单（级联删除订单明细）
        public void DeleteOrder(int orderId)
        {
            using (var context = new OrderDbContext())
            {
                var order = context.Orders.Include(o => o.OrderDetailsList)
                                          .FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                {
                    throw new ApplicationException("订单不存在！");
                }
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        // 更新订单信息（简单示例：更新客户名称和订单明细）
        public void UpdateOrder(Order updatedOrder)
        {
            using (var context = new OrderDbContext())
            {
                var order = context.Orders.Include(o => o.OrderDetailsList)
                                          .FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);
                if (order == null)
                {
                    throw new ApplicationException("订单不存在！");
                }
                // 更新客户名称
                order.Customer = updatedOrder.Customer;

                // 此示例中，先清空原有订单明细，再添加更新后的明细
                order.OrderDetailsList.Clear();
                foreach (var detail in updatedOrder.OrderDetailsList)
                {
                    order.OrderDetailsList.Add(detail);
                }
                context.SaveChanges();
            }
        }

        // 根据订单号查询订单
        public Order GetOrder(int orderId)
        {
            using (var context = new OrderDbContext())
            {
                return context.Orders.Include(o => o.OrderDetailsList)
                                     .FirstOrDefault(o => o.OrderId == orderId);
            }
        }

        // 查询所有订单（注意：返回 List 便于立即执行查询）
        public IQueryable<Order> GetOrders()
        {
            var context = new OrderDbContext();
            return context.Orders.Include(o => o.OrderDetailsList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace homework1
{
   

    // 测试程序
    class Program
    {
        static void Main(string[] args)
        {
            // 创建订单服务对象
            OrderService orderService = new OrderService();

            try
            {
                // 添加订单
                Order order1 = new Order(1, "张三");
                order1.AddOrderDetails(new OrderDetails("苹果", 10, 5.0));
                order1.AddOrderDetails(new OrderDetails("香蕉", 5, 3.0));
                orderService.AddOrder(order1);

                Order order2 = new Order(2, "李四");
                order2.AddOrderDetails(new OrderDetails("橙子", 8, 4.0));
                orderService.AddOrder(order2);

                Order order3 = new Order(3, "王五");
                order3.AddOrderDetails(new OrderDetails("苹果", 3, 5.0));
                order3.AddOrderDetails(new OrderDetails("梨", 7, 4.5));
                orderService.AddOrder(order3);

                Console.WriteLine("添加订单成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"添加订单时出错：{ex.Message}");
            }

            // 查询测试
            Console.WriteLine("\n按订单号查询订单 1：");
            var ordersById = orderService.QueryByOrderId(1);
            ordersById.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n按客户查询订单 张三：");
            var ordersByCustomer = orderService.QueryByCustomer("张三");
            ordersByCustomer.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n按商品名称查询包含 苹果 的订单：");
            var ordersByProduct = orderService.QueryByProductName("苹果");
            ordersByProduct.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n查询订单总金额大于30的订单：");
            var ordersByAmount = orderService.QueryByTotalAmount(30);
            ordersByAmount.ForEach(o => Console.WriteLine(o));

            // 修改测试
            try
            {
                // 修改订单 2，将客户名称改为 "李雷" 并增加一条明细
                Order orderToUpdate = orderService.GetAllOrders().FirstOrDefault(o => o.OrderId == 2);
                if (orderToUpdate != null)
                {
                    orderToUpdate.Customer = "李雷";
                    orderToUpdate.AddOrderDetails(new OrderDetails("葡萄", 10, 2.5));
                    orderService.UpdateOrder(orderToUpdate);
                    Console.WriteLine("\n修改订单成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"修改订单时出错：{ex.Message}");
            }

            // 删除测试
            try
            {
                // 删除订单 3
                orderService.DeleteOrder(3);
                Console.WriteLine("\n删除订单成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"删除订单时出错：{ex.Message}");
            }

            // 排序测试
            Console.WriteLine("\n默认按订单号排序后的订单：");
            var sortedOrders = orderService.SortOrders();
            sortedOrders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n按总金额自定义排序后的订单：");
            var sortedByAmount = orderService.SortOrders(o => o.TotalAmount);
            sortedByAmount.ForEach(o => Console.WriteLine(o));

            // 暂停控制台
            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }
    }
}

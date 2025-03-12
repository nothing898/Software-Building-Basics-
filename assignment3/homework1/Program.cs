using System;
using System.Collections.Generic;
namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<Shape> shapes = new List<Shape>();

            // 随机创建10个形状
            for (int i = 0; i < 10; i++)
            {
                // 随机选择形状类型：1,2,3
                int shapeType = rand.Next(1, 4);
                // 为不同形状生成参数，取值范围 1~10
                double p1 = rand.NextDouble() * 9 + 1;
                double p2 = rand.NextDouble() * 9 + 1;
                double p3 = rand.NextDouble() * 9 + 1;
                Shape s = ShapeFactory.CreateShape(shapeType, p1, p2, p3);
                shapes.Add(s);
            }

            double totalArea = 0;
            Console.WriteLine("各形状及其面积：");
            foreach (Shape s in shapes)
            {
                if (s != null && s.IsValid)
                {
                    double area = s.CalculateArea();
                    totalArea += area;
                    Console.WriteLine($"{s,-40} － 面积：{area:F2}");
                }
                else
                {
                    Console.WriteLine($"{s,-40} － 无法构成合法的形状");
                }
            }

            Console.WriteLine($"\n所有有效形状的总面积：{totalArea:F2}");
            Console.ReadLine();
        }
    }
}

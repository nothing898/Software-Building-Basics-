using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入第一个数字: ");
            string input1 = Console.ReadLine();
            double number1;
            if (!double.TryParse(input1, out number1))
            {
                Console.WriteLine("输入无效，请输入有效的数字。");
                return;
            }

            Console.Write("请输入运算符 (+, -, *, /): ");
            string op = Console.ReadLine();
            if (op != "+" && op != "-" && op != "*" && op != "/")
            {
                Console.WriteLine("无效的运算符！");
                return;
            }

            Console.Write("请输入第二个数字: ");
            string input2 = Console.ReadLine();
            double number2;
            if (!double.TryParse(input2, out number2))
            {
                Console.WriteLine("输入无效，请输入有效的数字。");
                return;
            }

            double result = 0;

            switch (op)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    if (number2 == 0)
                    {
                        Console.WriteLine("除数不能为零！");
                        return;
                    }
                    else
                    {
                        result = number1 / number2;
                    }
                    break;
            }


            Console.WriteLine("计算结果: " + result);

        }
    }
}

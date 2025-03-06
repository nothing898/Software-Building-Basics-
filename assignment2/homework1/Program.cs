using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input=Input.GetInput("请输入一个整数:");

            int x;
            if (!int.TryParse(input,out x))
            {
                Output.SendWrongInfo("输入不是一个整数");
                return;
            }

            int[] datas=Calculator.GetPrime(x);

            string[] stringDatas = Array.ConvertAll(datas,x=>x.ToString()); 

            Output.SendOutput("结果是:",stringDatas);
        }
    }
}

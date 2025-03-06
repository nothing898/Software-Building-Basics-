using System;
using System.Collections.Generic;

namespace homework2
{


    class Program
    {
        static void Main(string[] args)
        {
            List<string>inputs=Input.GetMutiLines("请输入矩阵");
            int[] datas;
            try
            {
                datas=Parser.StrToNum(inputs);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            List<string> outputs=new List<string>();
            outputs.Add("最大值为:"+Convert.ToString(Calculator.GetMax(datas))+"\n");
            outputs.Add("最小值为:" + Convert.ToString(Calculator.GetMin(datas)) + "\n");
            outputs.Add("和为:" + Convert.ToString(Calculator.GetSum(datas)) + "\n");
            outputs.Add("平均值为:" + Convert.ToString(Calculator.GetMean(datas)) + "\n");

            Output.SendOutput(outputs.ToArray());
        }
    }
}

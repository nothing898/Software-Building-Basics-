using System;
using System.Collections.Generic;

namespace homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = Input.GetMutiLines("请输入矩阵的每一行（数字之间用空格隔开，输入空行结束）:");

            string[][] matrix=Parser.StrToMatrix(inputs);

            bool result;
            try
            {
                result= Calculator.IfMatrix(matrix);
            }
            catch (Exception e)
            {
                Output.SendOutput(new string[] { e.Message });
                return;
            }

            if (result) Output.SendOutput(new string[] { "True" });
            else Output.SendOutput(new string[] { "False" });

        }
    }
}

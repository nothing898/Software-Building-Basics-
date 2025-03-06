using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Calculator
    {
        static public double GetMean(int [] datas)
        {
            if (datas.Length == 0) return 0;
            return GetSum(datas) / datas.Length;     
        }
        static public int GetSum(int[] datas)
        {
            return datas.Sum();
        }
        static public int GetMax(int[] datas)
        {
            return datas.Max();
        }
        static public int GetMin(int[] datas)
        {
            return datas.Min();
        }
    }
}

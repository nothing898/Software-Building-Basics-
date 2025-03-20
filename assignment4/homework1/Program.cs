using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[]args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for(int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            intlist.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            //最大值
            int max = int.MinValue;
            intlist.ForEach(x => { if (x > max) max = x; });
            Console.WriteLine("最大值" + max);
            //最小值
            int min = int.MaxValue;
            intlist.ForEach(x => { if (x < max) min = x; });
            Console.WriteLine("最小值" + min);
            //求和
            int sum = 0;
            intlist.ForEach(x =>  sum+=x );
            Console.WriteLine("总和" + sum);

        }
    }
}

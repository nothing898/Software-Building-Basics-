using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Calculator
    {
        static public int [] GetPrime(int x)
        {
            if(x==0)return new int[1]{0 };
            if (x < 0) x = -x;
            List<int> ans=new List<int> { };
            int divisor = 2;
            while (x != 1)
            {
                if (x % divisor == 0)
                {
                    x /= divisor;
                    
                    if (!ans.Contains(divisor))
                    {
                        ans.Insert(0,divisor);
                    }

                    divisor--;
                }

                divisor++;
            }
            return ans.ToArray();        
        }
    }
}

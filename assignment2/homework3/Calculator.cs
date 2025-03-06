using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Calculator
    {
        static public string  GetNumber(int n)
        {
            
           
                
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

                
            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                        
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            string data="";
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    data += $"{i} ";
                }
            }
            return data;
        

    }
}
}

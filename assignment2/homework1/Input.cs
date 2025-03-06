using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Input
    {
        static public string GetInput(string promote="")
        {
            string input;
            Console.WriteLine(promote);
            input=Console.ReadLine();
            return input;  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Input
    {
        static public string GetSingleLine(string promote="")
        {
            string input;
            Console.WriteLine(promote);
            input=Console.ReadLine();
            return input;  
        }
        static public List<string> GetMutiLines(string promote = "")
        {
            List<string> lines = new List<string>();
            string input;
            Console.WriteLine(promote);
            while((input = Console.ReadLine()) != "")
            {
                lines.Add(input);
            }
            return lines;
        }
    }
}

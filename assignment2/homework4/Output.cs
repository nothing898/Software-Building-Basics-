using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Output
    {
        static public void SendOutput(string [] datas,string promote= "")
        {
            Console.WriteLine(promote);
            foreach( var data in datas)
            {
                Console.Write($"{data}");
            }
        }
        static public void SendWrongInfo(string promote)
        {
            Console.WriteLine("Error: "+promote);
        }
    }
}

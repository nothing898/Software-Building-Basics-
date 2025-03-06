using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Parser
    {
        static public int[] StrToNum(List<string>datas)
        {
            List<int> result=new List<int>();
            foreach (var data in datas)
            {
                string[] tokens = data.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach(var token in tokens)
                {
                    int number;
                    if(!int.TryParse(token,out number))
                    {
                        throw new Exception("Error:数据不全为整数");

                    }
                    result.Add(number);
                }
            }

            return result.ToArray();
        }
    }
}

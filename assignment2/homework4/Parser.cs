using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Parser
    {
        static public string[][] StrToMatrix(List<string>lines)
        {
            List<string[]> matrixList = new List<string[]>();
            foreach (string line in lines)
            {
                
                string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                matrixList.Add(tokens);
            }
            string[][] matrix = matrixList.ToArray();
            return matrix;
        }
    }
}

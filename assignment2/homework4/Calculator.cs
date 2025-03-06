using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Calculator
    {
        static public bool IfMatrix(string[][] matrix)
        {
            
            if (matrix == null || matrix.Length == 0)
                return true;

            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;

            
            for (int i = 1; i < rowCount; i++)
            {
                
                if (matrix[i].Length != colCount)
                {
                    throw new Exception("Error:矩阵每行列数应相同");
                    
                }

                
                for (int j = 1; j < colCount; j++)
                {
                    if (matrix[i][j] != matrix[i - 1][j - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

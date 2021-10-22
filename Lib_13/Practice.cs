using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_13
{
    public class Practice
    {
        public static void MinimumValueMatrix(int[,] matrix, out string result)
        {
            List<int> element = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int increment = 1;
                int diminution = 1;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] > matrix[i, j + 1])
                    {
                        diminution++;
                    }
                    if (matrix[i, j] < matrix[i, j + 1])
                    {
                        increment++;
                    }
                }
                if (increment == matrix.GetLength(1))
                {
                    element.Add(matrix[i, 0]);
                }
                if (diminution == matrix.GetLength(1))
                {
                    element.Add(matrix[i, matrix.GetLength(1) - 1]);
                }
            }
            if (element.Count == 0)
            {
                result = "0";
            }
            else
            {
                result = element.Min().ToString();
            }
        }
    }
}

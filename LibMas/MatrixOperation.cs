using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibMas
{
    public class MatrixOperation
    {
        public static void FillMatrix(int[,] matrix, int fillValue)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = fillValue;
                }
            }
        }
        public static void FillRandomValues(int[,] matrix, int minValue, int maxValue)
        {
            Random randomNumber = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = randomNumber.Next(minValue, maxValue);
                }
            }
        }

        public static void ClearMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public static void SaveMatrix(string path, int[,] matrix)
        {
            using (StreamWriter save = new StreamWriter(path))
            {
                save.WriteLine(matrix.GetLength(0));
                save.WriteLine(matrix.GetLength(1));
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        save.WriteLine(matrix[i, j]);
                    }
                }
            }
        }
        public static void OpenMatrix(string path, out int[,] matrix)
        {
            using (StreamReader open = new StreamReader(path))
            {
                int row = Convert.ToInt32(open.ReadLine());
                int column = Convert.ToInt32(open.ReadLine());
                matrix = new int[row, column];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = Convert.ToInt32(open.ReadLine());
                    }
                }
            }
        }
    }
}

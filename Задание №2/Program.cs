using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int M_matrix = 5, N_matrix = 5; // M, i - строка; N,j - столбец
            int[,] matrix = new int[M_matrix, N_matrix];
            for (int i = 0; i < M_matrix; i++)
            {
                for (int j = 0; j < N_matrix; j++)
                {
                    if (i < 1 || j >= i - 1) // Условие для заполнения конкретного элемента массива 1 или 0
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            Console.WriteLine("Получившийся массив:");
            for (int i = 0; i < M_matrix; i++)
            {
                for (int j = 0; j < N_matrix; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
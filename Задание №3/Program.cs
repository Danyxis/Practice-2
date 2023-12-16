using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int M_matrix = 5, N_matrix = 5; // M, i - строка; N,j - столбец
            int[,] matrix = new int[M_matrix, N_matrix];
            int currentNumber = 1; // Начальное значение для заполнения элементов массива
            int left = 0; // Левая граница текущей области
            int right = N_matrix - 1; // Правая граница текущей области
            int top = 0; // Верхняя граница текущей области
            int bottom = M_matrix - 1; // Нижняя граница текущей области

            while (currentNumber <= M_matrix * N_matrix) // Пока все ячейки матрицы не будут заполнены
            {
                for (int i = left; i <= right; i++) // Заполняем матрицу слева направо
                {
                    matrix[top, i] = currentNumber++;
                }
                top++; // Смещаем верхнюю границу

                for (int i = top; i <= bottom; i++) // Заполняем матрицу сверху вниз
                {
                    matrix[i, right] = currentNumber++;
                }
                right--; // Смещаем правую границу

                for (int i = right; i >= left; i--) // Заполняем матрицу справа налево
                {
                    matrix[bottom, i] = currentNumber++;
                }
                bottom--; // Смещаем нижнюю границу

                for (int i = bottom; i >= top; i--) // Заполняем матрицу снизу вверх
                {
                    matrix[i, left] = currentNumber++;
                }
                left++; // Смещаем левую границу
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size;
            Console.Write("Введите размерность массива: ");
            size = int.Parse(Console.ReadLine());
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = i + 1;
            }
            Console.WriteLine("Массив в обратном порядке:");
            for (int i = size - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.Write("\n");
        }
    }
}
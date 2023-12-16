using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Operation
{
    Addition = 1, // Сложение
    Subtraction, // Вычитание
    Multiplication, // Умножение
    Division, // Деление
    RemainderDivision, // Остаток от деления
    Exponentiation, // Возведение в степень
    SquareRoot // Вычисление квадратного корня
}

public class Calculator
{
    public void Addition(double firstValue, double secondValue) // Сложение
    {
        double result = firstValue + secondValue;
        Console.WriteLine($"Результат: сумма {firstValue} и {secondValue} равна {result} \n");
    }
    public void Subtraction(double firstValue, double secondValue) // Вычитание
    {
        double result = firstValue - secondValue;
        Console.WriteLine($"Результат: разность {firstValue} и {secondValue} равна {result} \n");
    }
    public void Multiplication(double firstValue, double secondValue) // Умножение
    {
        double result = firstValue * secondValue;
        Console.WriteLine($"Результат: произведение {firstValue} и {secondValue} равно {result} \n");
    }
    public void Division(double firstValue, double secondValue) // Деление
    {
        if (secondValue != 0)
        {
            double result = firstValue / secondValue;
            Console.WriteLine($"Результат: частное {firstValue} и {secondValue} равно {result} \n");
        }
        else
        {
            Console.WriteLine("Ошибка! Деление на ноль запрещено! \n");
        }
    }
    public void RemainderDivision(double firstValue, double secondValue) // Остаток от деления
    {
        if (secondValue != 0)
        {
            double result = firstValue % secondValue;
            Console.WriteLine($"Результат: остаток от деления {firstValue} на {secondValue} равно {result} \n");
        }
        else
        {
            Console.WriteLine("Ошибка! Деление на ноль запрещено! \n");
        }
    }
    public void Exponentiation(double firstValue, double secondValue) // Возведение в степень
    {
        double result = (double)Math.Pow(firstValue, secondValue);
        Console.WriteLine($"Результат: возведение {firstValue} в степень {secondValue} равно {result} \n");
    }
    public void SquareRoot(double firstValue) // Вычисление квадратного корня
    {
        if (firstValue >= 0)
        {
            double result = (double)Math.Sqrt(firstValue);
            Console.WriteLine($"Результат: квадратный корень из {firstValue} равен {result} \n");
        }
        else
        {
            Console.WriteLine("Ошибка! Вычисление квадратного корня из отрицательного числа запрещено! \n");
        }
    }
}

namespace Task_5_Enumerations
{
    internal class Program
    {
        static void DoOperation(Operation op, Calculator calc, double firstValue, double secondValue) // Выбор операции
        {
            switch (op)
            {
                case Operation.Addition: calc.Addition(firstValue, secondValue); break;
                case Operation.Subtraction: calc.Subtraction(firstValue, secondValue); break;
                case Operation.Multiplication: calc.Multiplication(firstValue, secondValue); break;
                case Operation.Division: calc.Division(firstValue, secondValue); break;
                case Operation.RemainderDivision: calc.RemainderDivision(firstValue, secondValue); break;
                case Operation.Exponentiation: calc.Exponentiation(firstValue, secondValue); break;
                case Operation.SquareRoot: calc.SquareRoot(firstValue); break;
                default: Console.WriteLine("Ошибка! Некорректный ввод номера операции! Попробуйте заново!\n"); break;
            }
        }
        static void Main(string[] args)
        {
            double firstValue, secondValue;
            string operationInput;
            Operation op;
            Calculator calc = new Calculator();
            Console.Title = "Калькулятор";
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            do
            {
                Console.Write("Введите 1-ое число: ");
                firstValue = double.Parse(Console.ReadLine());
                Console.Write("Введите 2-ое число: ");
                secondValue = double.Parse(Console.ReadLine());

                Console.WriteLine("Номера и названия операций:");
                int number = 1;
                foreach (Operation i in Enum.GetValues(typeof(Operation))) // Вывод операций
                {
                    Console.WriteLine($"{number++} - {i}");
                }

                Console.Write("Введите номер операции или её название: ");
                operationInput = Console.ReadLine();
                if (Enum.TryParse(operationInput, out op)) // Преобразование и проверка на корректность введённой пользователем операции в тип Enum
                {
                    DoOperation(op, calc, firstValue, secondValue);
                }
                else
                {
                    Console.WriteLine("Ошибка! Неккоректный ввод названия операции! Попробуйте заново!\n");
                }
                Console.WriteLine("Для продолжения нажмите Enter, для выхода - Escape!");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
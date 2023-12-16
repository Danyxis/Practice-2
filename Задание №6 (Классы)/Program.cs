using My_Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book a = new Book(); // Создание объекта (книги) без параметров, дальнейшая инициализация некорректными данными и публикация
            //a.Author_name = "Пушк1н Александр Сергеевич";
            //a.Name = "Кап*танская дочка";
            //a.Set_number_chapters_and_pages(-100, 0);
            //a.Type = Type_Book.EMPTY;
            //a.Publication("М1сква", "a333-11111-234127", 0);

            Console.WriteLine("---------------------------------------");

            a.Author_name = "Пушкин Александр Сергеевич"; // Инициализация объекта (книги) корректными данными и публикация
            a.Name = "Капитанская дочка";
            a.Set_number_chapters_and_pages(100, 10);
            a.Type = Type_Book.Electronic;
            a.Publication("123-4-56789-123-4", "Москва", 2010);

            Console.WriteLine("---------------------------------------");

            /*a.Author_name = "Толстой Лев Николаевич";*/ // Попытка изменения данных объекта (книги) после её публикации
            //a.Name = "Война и мир";
            //a.Set_number_chapters_and_pages(1000, 25);
            //a.Type = Type_Book.Paperback;
            //a.Publication("987-6-54321-012-3", "СПБ", 2001);

            Console.WriteLine("---------------------------------------");

            Console.WriteLine($"ФИО: {a.Author_name}"); // Возврат данных объекта (книги)
            Console.WriteLine($"Название: {a.Name}");
            Console.WriteLine($"Тип: {a.Type}");
            a.Get_average_pages_per_chapter();

            Console.WriteLine("---------------------------------------");

            // Создание объекта (книги) с некорректными параметрами, попытка публикации
            //Book b = new Book("Гоголь Никол1й Васильевич", "Мёртвые д*ши", "1СТ", -1, -100, 0, Type_Book.EMPTY, "123-4-56789-321-00000000", true);

            Console.WriteLine("---------------------------------------");

            // Создание объекта (книги) с корректными параметрами, публикация, вывод сведений об объекте
            Book c = new Book("Гоголь Николай Васильевич", "Мёртвые души", "АСТ", 2005, 200, 20, Type_Book.Hardback, "123-4-56789-321-0", false);
            c.Output_Information();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace My_Book
{
    public enum Type_Book
    {
        Electronic,
        Paperback,
        Hardback,
        EMPTY
    }
    internal class Book
    {
        private string author_name; // ФИО автора книги
        private string name; // Название книги
        private string publishing_house; // Издательство книги
        private int year_publishing; // Год издания книги
        private int number_pages; // Количество страниц в книге
        private int number_chapters; // Количество глав в книге
        private Type_Book type; // Тип книги
        private string isbn; // ISBN книги
        private bool state; // Состояние книги (true - издана, false - не издана)

        public Book()
        {
            author_name = ""; name = ""; publishing_house = ""; year_publishing = 0; number_pages = 0; number_chapters = 0; type = Type_Book.EMPTY;
            isbn = ""; state = false;
        }

        public Book(string Author_name, string Name, string Publishing_house, int Year_publishing,
    int Number_pages, int Number_chapters, Type_Book Type, string ISBN, bool State) // Конструктор без параметров
        {
            author_name = "";
            name = "";
            publishing_house = "";
            year_publishing = 0;
            number_pages = 0;
            number_chapters = 0;
            type = Type_Book.EMPTY;
            isbn = "";
            state = false;

            if (!Author_name.All(symbol => char.IsLetter(symbol) || char.IsWhiteSpace(symbol))) // ФИО автора книги
            {
                throw new Exception("Некорректный ввод ФИО автора книги (содержит цифру или другой неподходящий символ)!");
            }
            else author_name = Author_name;

            if (!Name.All(symbol => char.IsLetter(symbol) || char.IsWhiteSpace(symbol) || char.IsDigit(symbol))) // Название книги
            {
                throw new Exception("Некорректный ввод названия книги (содержит неподходящий символ)!");
            }
            else name = Name;

            if (!Publishing_house.All(symbol => char.IsLetter(symbol) || char.IsWhiteSpace(symbol) || symbol == '-')) // Издательство книги
            {
                throw new Exception("Некорректный ввод издательства книги (содержит цифру или другой неподходящий символ)!");
            }
            else publishing_house = Publishing_house;

            if (Year_publishing <= 0 || Year_publishing > 2023) // Год издания книги
            {
                throw new Exception("Некорректный ввод года издания книги!");
            }
            else year_publishing = Year_publishing;

            if (Number_pages < 0 || Number_pages > 2500) // Количество страниц в книге
            {
                throw new Exception("Некорректный ввод количества страниц книги!");
            }
            else number_pages = Number_pages;

            if (Number_chapters < 0 || Number_chapters > 150) // Количество глав в книге
            {
                throw new Exception("Некорректный ввод количества глав книги!");
            }
            else number_chapters = Number_chapters;

            if ((Number_pages == 0 && Number_chapters != 0) || (Number_pages != 0 && Number_chapters == 0)) // Количество страниц и глав в книге одновременно
            {
                throw new Exception("Количество глав и страниц в книге могут быть равны 0 только одновременно!");
            }
            else
            {
                number_pages = Number_pages;
                number_chapters = Number_chapters;
            }

            if (Type == Type_Book.EMPTY) // Тип книги
            {
                throw new Exception("Некорректный ввод типа книги!");
            }
            else type = Type;

            if (ISBN.Length != 17) // ISBN книги
            {
                throw new Exception("Некорректный ввод ISBN книги (длина ISBN должна быть 17 символов)!");
            }
            else
            {
                if (!(ISBN.All(symbol => char.IsDigit(symbol) || symbol == '-')))
                {
                    throw new Exception("Некорректный ввод ISBN книги (используйте только цифры и тире: xxx-x-xxxxx-xxx-x)!");
                }
                else isbn = ISBN;
            }

            if ((author_name == "" || name == "" || publishing_house == "" || isbn == "") == true || 
                (year_publishing == 0 || number_pages == 0 || number_chapters == 0) || 
                type == Type_Book.EMPTY) // Если не все поля заполнены и указаны корректно, то книга не будет издана
            {
                throw new Exception("Книга не была издана!");
            }
            else // Иначе книга будет издана
            {
                state = true;
                Console.WriteLine("Книга была издана!");
            }
        }

        public string Author_name // Свойство ФИО автора книги
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("ФИО автора книги нельзя редактировать, так как книга уже издана!");
                }
                else
                {
                    if (!value.All(symbol => char.IsLetter(symbol) || char.IsWhiteSpace(symbol))) // ФИО автора книги
                    {
                        throw new ArgumentException("Некорректный ввод ФИО автора книги (содержит цифру или другой неподходящий символ)!");
                    }
                    else author_name = value;
                }
            }
            get { return author_name; }
        }

        public string Name // Свойство названия книги
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("Название книги нельзя редактировать, так как книга уже издана!" );
                }
                else
                {
                    if (!value.All(symbol => char.IsLetter(symbol) || char.IsWhiteSpace(symbol) || char.IsDigit(symbol))) // Название книги
                    {
                        throw new ArgumentException("Некорректный ввод названия книги (содержит неподходящий символ)!");
                    }
                    else name = value;
                }
            }
            get { return name; }
        }

        public Type_Book Type // Свойство типа книги
        {
            set
            {
                if (state == true)
                {
                    throw new Exception("Тип книги нельзя редактировать, так как книга уже издана!");
                }
                else
                {
                    if (value == Type_Book.EMPTY) // Тип книги
                    {
                        throw new ArgumentException("Некорректный ввод типа книги!");
                    }
                    else type = value;
                }
            }
            get { return type; }
        }

        public void Get_average_pages_per_chapter() // Определение среднего количества страниц в главе книги
        {
            if (number_pages == 0)
                Console.WriteLine("Среднее количество страниц в главе: 0");
            else
                Console.WriteLine($"Среднее количество страниц в главе: {(double)number_pages / number_chapters}");
        }

        public void Set_number_chapters_and_pages(int Number_pages, int Number_chapters) // Установка количества глав и количества страниц в книге
        {
            if (state == true)
            {
                throw new Exception("Количество глав и страниц в книге нельзя редактировать, так как книга уже издана!");
            }
            else
            {
                if (Number_pages < 0 || Number_pages > 2500) // Количество страниц в книге
                {
                    throw new ArgumentOutOfRangeException("Некорректный ввод количества страниц книги!");
                }
                else number_pages = Number_pages;

                if (Number_chapters < 0 || Number_chapters > 150) // Количество глав в книге
                {
                    throw new ArgumentOutOfRangeException("Некорректный ввод количества глав книги!");
                }
                else number_chapters = Number_chapters;

                if ((Number_pages == 0 && Number_chapters != 0) || (Number_pages != 0 && Number_chapters == 0)) // Количество страниц и глав в книге одновременно
                {
                    throw new ArgumentException("Количество глав и страниц в книге могут быть равны 0 только одновременно!");
                }
                else
                {
                    number_pages = Number_pages;
                    number_chapters = Number_chapters;
                }
            }
        }

        public void Publication(string ISBN, string Publishing_house, int Year_publishing)
        // Издание книги в конкретном издательстве в заданном году с присвоением указанного ISBN
        {
            if (author_name == "") // ФИО автора книги
            {
                throw new Exception("Ошибка издания книги: Поле <ФИО автора> не заполнено!");
            }

            if (name == "") // Название книги
            {
                throw new Exception("Ошибка издания книги: Поле <Название> не заполнено!");
            }

            if (number_pages == 0) // Количество страниц в книге
            {
                throw new Exception("Ошибка издания книги: Поле <Количество страниц> не заполнено!");
            }

            if (number_chapters == 0) // Количество глав в книге
            {
                throw new Exception("Ошибка издания книги: Поле <Количество глав> не заполнено!");
            }

            if (type == Type_Book.EMPTY) // Тип книги
            {
                throw new Exception("Ошибка издания книги: Поле <Тип> не заполнено!");
            }

            if (publishing_house == "" && isbn == "" && year_publishing == 0) // Если данная книга не была издана
            {
                if (!Publishing_house.All(symbol => char.IsLetter(symbol) || char.IsWhiteSpace(symbol) || symbol == '-')) // Издательство книги
                {
                    throw new ArgumentException("Ошибка издания книги: Некорректный ввод издательства книги (содержит цифру или другой неподходящий символ)!");
                }
                else publishing_house = Publishing_house;

                if (Year_publishing <= 0 || Year_publishing > 2023) // Год издания книги
                {
                    throw new ArgumentException("Ошибка издания книги: Некорректный ввод года издания книги!");
                }
                else year_publishing = Year_publishing;

                if (ISBN.Length != 17) // ISBN книги
                {
                    throw new ArgumentException("Ошибка издания книги: Некорректный ввод ISBN книги (длина ISBN должна быть 17 символов)!");
                }
                else
                {
                    if (!(ISBN.All(symbol => char.IsDigit(symbol) || symbol == '-')))
                    {
                        throw new ArgumentException("Ошибка издания книги: Некорректный ввод ISBN книги (используйте только цифры и тире: xxx-x-xxxxx-xxx-x)!");
                    }
                    else isbn = ISBN;
                }
            }
            else { throw new Exception("Данная книга уже издана!"); } // Иначе данная книга уже издана
            state = true;
            Console.WriteLine("Книга была издана!"); // Если все поля заполнены и указаны корректно, то книга будет издана, иначе не будет издана
        }

        public void Output_Information()
        {
            Console.WriteLine($"ФИО автора: {author_name}");
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Издательство: {publishing_house}");
            Console.WriteLine($"Год издания: {year_publishing}");
            Console.WriteLine($"Количество страниц: {number_pages}");
            Console.WriteLine($"Количество глав: {number_chapters}");
            Console.Write("Тип: ");
            switch (type)
            {
                case Type_Book.Electronic: Console.WriteLine("Электронная"); break;
                case Type_Book.Paperback: Console.WriteLine("В мягкой обложке"); break;
                case Type_Book.Hardback: Console.WriteLine("В твёрдой обложке"); break;
                default: Console.WriteLine(""); break;
            }
            Console.WriteLine($"ISBN: {isbn}");
        }
    }
}
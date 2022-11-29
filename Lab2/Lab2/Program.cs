using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Xml.Linq;

//Cоздать класс Book: id, Название, Автор(ы), 
//Издательство, Год издания, Количество страниц, Цена,
//Тип переплета. Свойства и конструкторы должны 
//обеспечивать проверку корректности. 

namespace Lab2
{
    partial class Book
    {
        private readonly int id;
        private string name;
        public string nameCheck
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        private string authour { set; get; }
        private string publishing { set; get; }
        private int yearPublishing;
        public int yearPublishingCheck
        {
            set
            {
                if (value < 1900)
                {
                    yearPublishing = -1;
                }
                else
                {
                    yearPublishing = value;
                }
            }
            get
            {
                return yearPublishing;
            }
        }
        private int countPage;

        public int countPageCheck
        {
            set
            {
                if (value < 0)
                {
                    countPage = -1;
                }
                else
                {
                    countPage = value;
                }
            }
            get
            {
                return countPage;
            }
        }
        private int cost;

        public int costCheck
        {
            set
            {
                if (value < 0)
                {
                    cost = -1;
                }
                else
                {
                    cost = value;
                }
            }

            get
            {
                return cost;
            }
        }
        private string typeOfBinding { set; get; }
        const string info = "Информация об объекте";
        public Book()
        {
            Random rnd = new Random();
            id = rnd.Next(0, 100);
            nameCheck = "C++";
            authour = "Maksim Kryshtal";
            publishing = "Belarus";
            yearPublishingCheck = 1950;
            countPageCheck = 35;
            costCheck = 80;
            typeOfBinding = "Common";
            countObject(ref countObj);
        }

        public Book( string NAME, string AUTHOUR, string PUBLISHING, int YEAR, int COUNT, int COST , string TYPE)
        {
            Random rnd = new Random();
            id = rnd.Next(0, 100);
            nameCheck = NAME;
            authour = AUTHOUR;
            publishing = PUBLISHING;
            yearPublishingCheck = YEAR;
            countPageCheck = COUNT;
            costCheck = COST;
            typeOfBinding = TYPE;
            countObject(ref countObj);
        }

        public Book(int COUNT = 25, string AUTHOUR = "Maksim")
        {
            Random rnd = new Random();
            id = rnd.Next(0, 100);
            nameCheck = "Pascal";
            authour = AUTHOUR;
            publishing = "Belarus";
            yearPublishingCheck = 1940;
            countPageCheck = COUNT;
            costCheck = 79;
            typeOfBinding = "common";
            countObject(ref countObj);
        }

        public static int countObj = 0; 
        public void countObject(ref int size)
        {
            size++;
        }
        static Book()
        {
            Console.WriteLine("              Книги на мест\n__________________________________________");
        }

        private Book(int a) { }

        public static int proverka = 0;
        public static void list(Book book, string aut)
        {
            if (aut == book.authour)
            {
                Console.WriteLine("Книга: {0}", book.name);
            } else
            {
                proverka++;
            }
        }

        public static void listYear(Book book, int year)
        {
            if (book.yearPublishingCheck > year)
            {
                Console.WriteLine("Книга: {0}", book.name);
            } else
            {
                proverka++;
            }
        }



    }

    partial class Book
    {
        public static void showObj(Book book)
        {
            Console.WriteLine("{0} {1}", info, countObj);
            Console.WriteLine("ID = {0}", book.id);
            Console.WriteLine("Название = {0}", book.name);
            Console.WriteLine("Автор = {0}", book.authour);
            Console.WriteLine("Издательсво = {0}", book.publishing);
            Console.WriteLine("Год издательсва = {0}", book.yearPublishing);
            Console.WriteLine("Количество страниц = {0}", book.countPage);
            Console.WriteLine("Цена = {0}", book.cost);
            Console.WriteLine("Тип переплета = {0}\n", book.typeOfBinding);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Book book)
            {
                return yearPublishing == book.yearPublishing;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Название:{name}\nАвтор:{authour}\n";
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {

            Book pr0 = new Book();
            Book.showObj(pr0);
            Book pr1 = new Book("JS", "Roman Novikov", "Belarus", 1950, 200, 59, "Common");
            Book.showObj(pr1);
            Book pr2 = new Book(".NET", "Roman Novikov", "Belarus", 2001, 101, 99, "Common");
            Book.showObj(pr2);
            Book pr3 = new Book("C#", "Maksim", "Belarus", 2003, 150, 109, "Common");
            Book.showObj(pr3);
            Book pr4 = new Book(50);
            Book.showObj(pr4);
            

            Console.WriteLine("Сравнил 1 и 2 объект: {0}", pr0.Equals(pr1));
            Console.WriteLine("хэш-код(name) = {0}", pr0.GetHashCode());
            Console.WriteLine(pr0.ToString());
            Book[] book = new Book[Book.countObj];
            book[0] = pr0;
            book[1] = pr1;
            book[2] = pr2;
            book[3] = pr3;
            book[4] = pr4;
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 3)
            {
                switch (choice)
                {
                    case 1:
                        string check;
                        Console.Write("Введите имя автора: ");
                        check = Console.ReadLine();
                        Console.WriteLine("Книги автора {0}", check);
                        for (int i = 0; i < Book.countObj; i++)
                        {
                            Book.list(book[i], check);
                        }
                        if(Book.proverka == Book.countObj)
                        {
                            Console.WriteLine("Таких книг нет!!!");
                        }
                        Book.proverka = 0;
                        break;
                    case 2:
                        int checkNum;
                        Console.Write("Введите год: ");
                        checkNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Книги после {0} года выпуска", checkNum);
                        for (int i = 0; i < Book.countObj; i++)
                        {
                            Book.listYear(book[i], checkNum);
                        }
                        if (Book.proverka == Book.countObj)
                        {
                            Console.WriteLine("Таких книг нет!!!");
                        }
                        Book.proverka = 0;
                        break;
                    case 3:
                        break;
                }
                choice = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Анонимный тип");
            var BOOK = new {name = "C#" , authour = "Romka Novikov"};
            Console.WriteLine(BOOK.name);
        }
    }

   
}

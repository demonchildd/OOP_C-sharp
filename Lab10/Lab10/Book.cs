using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Book
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
        public string authour { set; get; }
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

        public Book(string NAME, string AUTHOUR, string PUBLISHING, int YEAR, int COUNT, int COST, string TYPE)
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
        


        public static void showObj(Book book)
        {
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

    
}

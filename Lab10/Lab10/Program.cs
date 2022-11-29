using System;
using System.Net.WebSockets;

namespace Lab10
{
    class MainClass
    {
        public static void Main()
        {
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.Write("Введите длину строки: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var lengthMonth = from mon in month
                           where mon.Length == n
                           select mon;
            foreach (string item in lengthMonth)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            string[] elseMonth = { "June", "July", "August", "December", "Junuary", "February" };
            var WinterSummer = month.Intersect(elseMonth);
            foreach (string item in WinterSummer)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            var order = from mon in month
                        orderby mon
                        select mon;
            foreach (string item in order)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            var last = month.Where(mon => mon.Length >= 4 && mon.ToLower().Contains('u'));
            foreach (string item in last)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n-----------------------------------------------");

            List<Book> book = new List<Book>();
            book.Add(new Book("C#", "Maks" , "Belarus", 2003, 190, 59, "Rare"));
            book.Add(new Book("C++", "Roman", "Belarus", 2000, 100, 49, "Rare"));
            book.Add(new Book("C", "Dimon", "Belarus", 2015, 99, 69, "Rare"));
            book.Add(new Book("Js", "Dima", "Belarus", 2019, 199, 48, "Rare"));
            book.Add(new Book("Java", "Maks", "Belarus", 2003, 150, 99, "Rare"));
            book.Add(new Book("C#", "Dima", "Belarus", 2005, 19, 96, "Rare"));
            book.Add(new Book("C", "Roman", "Belarus", 2017, 19, 103, "Rare"));
            book.Add(new Book("C++", "Maks", "Belarus", 2021, 45, 77, "Rare"));
            book.Add(new Book("C#", "Dima", "Belarus", 2000, 57, 88, "Rare"));
            book.Add(new Book("Js", "Maks", "Belarus", 2003, 95, 50, "Rare"));

            var listBook1 = book.Where(p => p.authour == "Maks" && p.yearPublishingCheck == 2003);
            foreach (Book item in listBook1)
            {
                Book.showObj(item);
            }
            Console.WriteLine("-----------------------------------------------");
            var listBook2 = book.Where(p => p.yearPublishingCheck > 2018);
            foreach (Book item in listBook2)
            {
                Book.showObj(item);
            }
            Console.WriteLine("-----------------------------------------------");

            int check = book.Min(p => p.countPageCheck);
            var listBook3 = book.Where(p => p.countPageCheck == check);
            foreach (Book item in listBook3)
            {
                Book.showObj(item);
            }
            Console.WriteLine("-----------------------------------------------");

            var buff = from p in book
                            orderby p.countPageCheck descending, p.costCheck
                            select p;
            var listBook4 = buff.Take(5);
            foreach (var item in listBook4)
            {
                Book.showObj(item);
            }
            Console.WriteLine("-----------------------------------------------");

            var listBook5 = book.OrderByDescending(p => p.costCheck);
            foreach (Book item in listBook5)
            {
                Book.showObj(item);
            }
            Console.WriteLine("-----------------------------------------------");


            var listBook6 = from p in book
                            where p.costCheck > 50
                            orderby p.costCheck
                            group p by p.authour;
            foreach (var item in listBook6)
            {
                Console.WriteLine(item.Key);
                foreach (var a in item)
                {
                    Console.WriteLine(a.nameCheck);
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------");
            int sum = book.Sum(p => p.costCheck);
            Console.WriteLine(sum);
            Console.WriteLine("-----------------------------------------------");

            bool pr = book.All(s => s.yearPublishingCheck > 1999);    
            Console.WriteLine(pr);
            Console.WriteLine("-----------------------------------------------");

            List<BookCheck> bookChecks = new List<BookCheck>();
            bookChecks.Add(new BookCheck("C#", "proga"));
             
            var listBook7 = from p in book
                            join c in bookChecks on p.nameCheck equals c.name
                            select new {Name = p.nameCheck, Authour = p.authour, Genre = c.genre};
            foreach (var item in listBook7)
            {
                Console.WriteLine($"{item.Name} {item.Authour} {item.Genre}");
            }

        }

    }


    class BookCheck
    {
        public string name;
        public string genre;
        public BookCheck(string name, string genre)
        {
            this.name = name;
            this.genre = genre;
        }
    }
}
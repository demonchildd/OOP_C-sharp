using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab7
{
    class MainClass
    {
        public static void Main()
        {
            CollectionType<int> intlist = new CollectionType<int>();
            intlist.AddList(5);
            intlist.AddList(4);
            intlist.AddList(9);
            intlist.AddList(10);
            intlist = intlist + 100;
            intlist.ShowList();
            try
            {
                intlist.DelValue(8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                
            }
            finally
            {
                Console.WriteLine("Проверяйте значения");
            }
            intlist.DelValue(10);
            intlist.ShowList();
            CollectionType<string> strlist = new CollectionType<string>();
            strlist.AddList("asdas");
            strlist.AddList("adsfsdf");
            strlist.AddList("assdfsdfds");
            strlist.ShowList();
            CollectionType<Textbook> person = new CollectionType<Textbook>();
            person.AddList(new Textbook("asdad",15, 15,10));
            person.AddList(new Textbook("asdsdfsdsdfd", 565, 45, 9));
            
            person.ShowList();
            person.FileLogger();
            strlist.FileLogger();
            intlist.FileLogger();
            Console.WriteLine("-------------------------------------");
            intlist.OutFile();
            Test<Textbook> test = new Test<Textbook>();
            test.AddList(new Textbook("asdad", 15, 15, 10));
            //Test<int> test1 = new Test<int>();
            









        }
    }

    
}
using Lab6;
using System;
using System.Diagnostics;

namespace Lab4
{
    public class mainClass
    {
        static void Main()
        {
            Journal journal = new Journal("RED", 13, 24, "PUSHKIN");
            journal.Print();
            Console.WriteLine($"Издательство {journal.Name} дорогое: {journal.Evaluation()}\n");
            Textbook textbook = new Textbook("azbuka", 25, 50, 1);
            textbook.ToString();

            Book book = new Book("DEAD", 120, 170, "LENIN");
            book.Print();
            Console.WriteLine($"Издательство {book.Name} дорогое: {book.Evaluation()}\n");

            Person person = new Person("C#", 150, 266, "NOVIKOV");
            person.Print();
            InformationLog Iperson = person;
            Iperson.Show();
            Console.WriteLine($"Издательство {person.Name} дорогое: {person.Evaluation()}\n");
            Iperson.Evaluation();

            Author author = new Author("C++", 120, 299, "DENISENKO");
            author.Print();

            Console.WriteLine("-----------------Printed-------------------");
            PrintedEdition[] all = new PrintedEdition[4];
            all[0] = new Book("asdfg", 11, 123, "war");
            all[1] = new Journal("ZXCVB", 13, 456, "MAKS");
            all[2] = new Person("ghjgj", 15, 16, "dimon");
            all[3] = new Textbook("hjkkh", 45, 78, 8);

            Printer printer = new Printer();
            printer.IAmPrinting(all[2]);
            printer.IAmPrinting(all[1]);
            printer.IAmPrinting(all[0]);
            printer.IAmPrinting(all[3]);


            Console.WriteLine("------------------As----------------------");
            InformationLog check = new Person("AS", 45, 46, "ASAS");
            Person over = check as Person;
            if (over == null)
            {
                Console.WriteLine("Провал");
            }
            else
            {
                over.ToString();
            }

            Console.WriteLine("-----------------Struct--------------------");
            MyInformation info = new MyInformation("Roman", "Novikov");
            info.GetInformation();


            Library library = new Library();
            library.Add(textbook);
            library.Add(author);
            library.Add(book);
            library.Add(all[3]);
            library.Print();

            Controller controller = new Controller();
            controller.Count(library.library);
            controller.Cost(library.library);

            string path = "D:\\Курс2\\ООП\\Lab6\\Lab6\\a.txt";
            Logger logger = new Logger(path);
            try
            {
                Textbook textbook1 = new Textbook("asdasd", 150, 45, 15);
            }
            catch (TextBookException obj)
            {
                Console.WriteLine($"Ошибка: {obj.Message}");
                Console.WriteLine($"Значение {obj.Number} введено некорректно\n");
            }


            try
            {
                Journal journal1 = new Journal("ADdsdfsd", -18, 15, "sdfsdf");
            }
            catch (CostException obj)
            {
                Console.WriteLine($"Ошибка: {obj.Message}");
                Console.WriteLine($"Значение {obj.Number} введено некорректно\n");
            }

            try
            {
                Book book1 = new Book("fsddsf", 15, 0, "Sdfs");
            }
            catch (CountException obj)
            {
                Console.WriteLine($"Ошибка: {obj.Message}");
                Console.WriteLine($"Значение {obj.Number} введено некорректно\n");
                logger.FileLogger(obj);
            }



            try
            {
                int x = 5;
                int y = x / 0;
                Console.WriteLine($"Результат: {y}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Исключение {ex.Message}\n");
                logger.FileLogger(ex);
            }

            try
            {
                object obj = "you";
                int num = (int)obj;
                Console.WriteLine($"Результат: {num}");
            }

            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                logger.FileLogger(ex);
                logger.ConsoleLogger();
            }

            try
            {

                string num = null;
                Console.WriteLine(num.ToUpper());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}\n");
            }

            try
            {

                int num = int.MaxValue;
                checked
                {
                    Console.WriteLine(num + 1);
                }

            }

            catch (OverflowException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}\n");
            }

            try
            {
                int[] numbers = new int[4];
                numbers[7] = 9;


            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}\n");
                
            }

            try
            {
                int[] numbers = new int[4];
                numbers[7] = 9;


            }
            catch
            {
                Console.WriteLine("Ошибочка");
            }
            finally
            {
                Console.WriteLine("Повторите снова\n");
            }


            try
            {
                Square("ab");
                void Square(string data)
                {
                    int x = int.Parse(data);
                    Console.WriteLine($"Квадрат числа {x}: {x * x}");
                }
            }
            catch (Exception ex) when (
            ex is FormatException
            || ex is ArgumentNullException
            || ex is OverflowException)
            {
                Console.WriteLine($"Исключение: {ex.Message}\n");
            }


            static void Method1()
            {
                try
                {
                    Method2();
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Catch в Method1 : {ex.Message}");
                }
                Console.WriteLine("Конец метода Method1");
            }
            static void Method2()
            {
                try
                {
                    int x = 8;
                    int y = x / 0;
                }
                finally
                {
                    Console.WriteLine("Блок finally в Method2");
                }
                Console.WriteLine("Конец метода Method2");
            }

            try
            {
                Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch в Main : {ex.Message}");
            }
            

            int pos = -25;
            //Debug.Assert(pos > 0); //Если это недопустимо, Assert выводит стек вызовов
            //Debugger.Break();
           
        }

    }
}

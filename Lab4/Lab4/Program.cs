using System;

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
        }



    }
}

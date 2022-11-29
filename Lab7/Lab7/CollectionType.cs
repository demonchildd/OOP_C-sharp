using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class CollectionType<T> : Collection<T>
    {
        public List<T> list = new List<T>();


        
        public void AddList(T value)
        {
            list.Add(value);
        }

        public void ShowList()
        {
            foreach (var item in list)
            {
                if (item is Textbook textbook)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
                else
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();

        }
       

        public static CollectionType<T> operator +(CollectionType<T> A, T value)
        {
            A.list.Add(value);
            return A;
        }
        public void DelValue( T value)
        {
            if (!list.Remove(value))
            {
                throw new Exception("Элемент не найдет");    
            }
        }

        static string path = "D:\\Курс2\\ООП\\Lab7\\Lab7\\a.txt";

        static CollectionType()
        {

            using (StreamWriter sw = new StreamWriter(path, false)) ;
           
        }


        internal async void FileLogger()
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (var item in list)
                {
                    if (item is Textbook textbook)
                    {
                        await sw.WriteLineAsync($"{item.ToString()} ");
                    }
                    else
                    {
                        await sw.WriteAsync($"{item} ");
                    }
                }
                await sw.WriteLineAsync("");

            }
        }

        internal async void OutFile()
        {
            string info = await File.ReadAllTextAsync(path);
            Console.WriteLine(info);
        }
    }
}

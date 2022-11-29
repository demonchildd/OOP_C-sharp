using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Linq;

namespace lab3
{
    public class LIST
    {
        public List<int> list = new List<int>();
        

        public static LIST operator >>(LIST lists, int position)
        {
            if (lists.list.Count >= position - 1)
            {
                lists.list.RemoveAt(position - 1);  
            }
            else
            {
                Console.WriteLine("Позиция введена неверно");
            }
            return lists;
        }

        public static LIST operator +(LIST lists,int position)
        {
            int value;
            Console.Write("Введите элемент: ");
            value = Convert.ToInt32(Console.ReadLine());
            if ((position - lists.list.Count) <= 1)
            {
                lists.list.Insert(position - 1, value);
            }
            else
            {
                Console.WriteLine("Позиция введена неверно");
            }
            return lists;
        }
        public static bool operator !=(LIST list1, LIST list2)
        {
            return list1.list.Count != list2.list.Count;
        }
        public static bool operator ==(LIST list1, LIST list2)
        {
            return list1.list.Count == list2.list.Count;
        }
        public static void ShowList(LIST lists)
        {
            Console.Write("Элементы списка: ");
            foreach (var number in lists.list)
                Console.Write("{0} ", number);
            Console.WriteLine();
        }

        public static void AddList(LIST lists, int value)
        {
            lists.list.Add(value);
        }

        public class Production
        {
            int id = 20;
            string? name = "EPAM";
            public Production()
            {
                Console.WriteLine($"ID = {id}");
                Console.WriteLine($"Name = {name}");
            }

        }

        public class Developer
        {
            int id = 25;
            string? name = "rrr";
            string? department = "ddd";
            public Developer()
            {
                Console.WriteLine($"ID = {id}");
                Console.WriteLine($"Name = {name}");
                Console.WriteLine($"Department = {department}");
            }
        }


    }

    class test
    {
        public static void Main(string[] args)
        {
            LIST list = new LIST();
            LIST.AddList(list, 10);
            LIST.AddList(list, 5);
            LIST.AddList(list, 7);
            LIST.AddList(list, 9);
            LIST.AddList(list, 11);
            LIST.AddList(list, 115);
            LIST.ShowList(list);
            list = list >> 5;
            LIST.ShowList(list);
            list = list + 2;
            LIST.ShowList(list);
            LIST list1 = new LIST();
            LIST.AddList(list1, 10);
            LIST.AddList(list1, 8);
            LIST.AddList(list1, 9);
            LIST.AddList(list1, 9);
            LIST.AddList(list1, 115);
            LIST.AddList(list1, 1155);
            LIST.ShowList(list1);
            Console.WriteLine(list != list1);

            LIST.Production production = new LIST.Production();
            LIST.Developer  developer = new LIST.Developer();

            Console.WriteLine($"Сумма = {list.Sum()}");
            list.DifferenceBetweenMaxMin();
            Console.WriteLine($"Количество элементов = {list.NumberOfElements()}");

            string str = "sdfsd sdfsdfdfsd5445 fds dsfsfdsf sdf";
            Console.WriteLine(str);
            Console.WriteLine($"Максимальная длина слова: {str.MaxLen()}");

            list.RemoveEnd();
            LIST.ShowList(list);

        }
    }
}

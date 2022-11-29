using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    internal class Computer : IComp
    {
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        int cost;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        

        public Computer(string name, string type, int cost)
        {
            Name = name;
            Type = type;
            Cost = cost;
          
        }
        

      
        public void Power()
        {
            if (Cost < 4000)
            {
                Console.WriteLine("Компьютер не мощный");
            }
            else
            {
                Console.WriteLine("Компьютер мощный");
            }
        }

        public void show()
        {
            Console.WriteLine("Я сделал лабу");
        }
        public void Test(int a, string str)
        {
            Console.WriteLine($"Строка: {str}");
            Console.WriteLine($"Число: {a}");
        }
        public override string ToString()
        {
            return String.Format($"Название: {Name}\tТип процессора: {Type}\tЦена: {Cost}");
        }
    }
}

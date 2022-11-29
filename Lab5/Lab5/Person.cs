using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Person : PrintedEdition, InformationLog
    {
        string? aut;
        public string Aut 
        { 
            get { return aut; }
            set { aut = value; }
        }

        internal Person(string name, int cost, int countPage, string aut) : base(name, cost, countPage)
        {
            Aut = aut;
        }

        internal override bool Evaluation()
        {
            if (Cost > 100)
                return true;
            return false;
        }

        bool InformationLog.Evaluation()
        {
            Console.WriteLine($"Книга {Name} дорогая: {Cost > 100}\n");
            return Cost > 100;
        }

        void InformationLog.Show()
        {
            Console.WriteLine($"Author: {Aut}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}\n");
        }
        internal override void Print()
        {
            Console.WriteLine($"Author: {Aut}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}\n");
        }

        public override string? ToString()
        {
            Console.WriteLine($"Author: {Aut}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}\n");
            return Name;
        }
    }
}

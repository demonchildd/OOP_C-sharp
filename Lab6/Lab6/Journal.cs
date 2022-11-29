using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Journal : PrintedEdition 
    {
        internal string aut;
        public string Aut
        {
            get { return aut; }
            set { aut = value; }
        }
        internal Journal(string name, int cost, int countPage, string aut) : base(name , cost, countPage)
        {
            Aut = aut;
        }

        internal override bool Evaluation()
        {
            if (Cost > 100)
                return true;
            return false;
        }
        internal override void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}");
            Console.WriteLine($"Author: {Aut}\n");
        }

        public override string? ToString()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}");
            Console.WriteLine($"Author: {Aut}\n");
            return Name;
        }
    }
}

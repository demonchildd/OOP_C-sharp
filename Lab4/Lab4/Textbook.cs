using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
{
    internal class Textbook : PrintedEdition
    {
        internal int forclass;
        public int ForClass
        {
            get { return forclass; }
            set { forclass = value; }
        }
        internal Textbook(string name, int cost, int countPage, int forclass) : base(name, cost, countPage)
        {
            ForClass = forclass;
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
            Console.WriteLine($"For class: {ForClass}\n");
        }

        public override string? ToString()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}");
            Console.WriteLine($"For class: {ForClass}\n");
            return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal sealed class Book : PrintedEdition
    {
        internal string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        internal Book(string name, int cost, int countPage, string genre) : base(name, cost, countPage)
        {
            Genre = genre;
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
            Console.WriteLine($"Genre: {Genre}\n");
        }

        public override string? ToString()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}");
            Console.WriteLine($"Genre: {Genre}\n");
            return Name;
        }
    }
}

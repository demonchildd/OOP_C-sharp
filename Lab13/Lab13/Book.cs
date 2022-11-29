using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab13
{
    [Serializable]
    public sealed class Book : PrintedEdition
    {
        [NonSerialized]
        public string genre;
        
        
        
        public Book(string name, int cost, int countPage, string genre) : base(name, cost, countPage)
        {
            this.genre = genre;
        }

        public Book() : base()
        {

        }
        public override bool Evaluation()
        {
            if (Cost > 100)
                return true;
            return false;
        }
        public override void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Count: {CountPage}");
            Console.WriteLine($"Genre: {genre}");
        }

        public override string? ToString()
        {
            Console.Write($"Name: {Name}");
            Console.Write($" --- Cost: {Cost}");
            Console.Write($" --- Count: {CountPage}");
            Console.Write($" --- Genre: {genre}\n");
            return Name;
        }
    }
}

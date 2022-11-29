using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
{
    internal partial class Textbook : PrintedEdition
    {
        
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Data
    {
        enum Day
        {
            Mondey,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        
    }

    struct MyInformation
    {
        string Name;
        string LastName;
        string Education = "БГТУ";

        public void GetInformation()
        {
            Console.WriteLine($"NAME: {Name}, LastName: {LastName}, Education: {Education}");
        }

        public MyInformation(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
    }
}

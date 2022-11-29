using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Controller : Library
    {
        int CountTextBook = 0;
        int CostBook = 0;
        public void Count(PrintedEdition[] library)
        {
            for (int i = 0; i < Library.CountLibrary; i++)
            {
                if (library[i] is Textbook textbook)
                {
                    CountTextBook++;
                }
            }
            Console.WriteLine($"Количество учебников: {CountTextBook}");
        }

        public void Cost(PrintedEdition[] library)
        {
            for (int i = 0; i < Library.CountLibrary; i++)
            {
                CostBook += library[i].Cost;
            }
            Console.WriteLine($"Количество учебников: {CostBook}\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Library
    {
        public PrintedEdition[] library = new PrintedEdition[100];

        public static int CountLibrary = 0;
        PrintedEdition[] lib
        {
            get { return library; }
            set { library = value; }
        }

        public void Add(PrintedEdition obj)
        {
            library[CountLibrary] = obj;
            CountLibrary++;
        }

        public void Delete(PrintedEdition obj)
        {
            for (int i = 0; i < CountLibrary; i++)
            {
                if (library[i] == obj)
                {
                    for (int j = i; j  < CountLibrary - 1; j ++)
                    {
                        library[j] = library[j + 1];
                    }
                }
            }
            CountLibrary--;
        }

        public void Print()
        {
            for (int i = 0; i < CountLibrary; i++)
            {
                library[i].ToString();
            }
        }

    }
}

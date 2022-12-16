using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_20
{

    class Persona
    {
        public void SeeTours(Agency agency)
        {
            ITourIterator iterator = agency.CreateNumerator();
            while (iterator.HasNext())
            {
                Tour book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }

    interface ITourIterator
    {
        bool HasNext();
        Tour Next();
    }
    interface ITourNumerable
    {
        ITourIterator CreateNumerator();
        int Count { get; }
        Tour this[int index] { get; }
    }
    class Tour
    {
        public string Name { get; set; }
    }

    class Agency : ITourNumerable
    {
        private Tour[] tours;
        public Agency()
        {
            tours = new Tour[]
            {
            new Tour{Name="Африка"},
            new Tour{Name="Португалия"},
            new Tour{Name="Бгту"}
            };
        }
        public int Count
        {
            get { return tours.Length; }
        }

        public Tour this[int index]
        {
            get { return tours[index]; }
        }
        public ITourIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }
    class LibraryNumerator : ITourIterator
    {
        ITourNumerable aggregate;
        int index = 0;
        public LibraryNumerator(ITourNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Tour Next()
        {
            return aggregate[index++];
        }
    }
}

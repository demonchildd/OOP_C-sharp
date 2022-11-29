using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab7
{
    internal class Test<T> where T : class
    {
        public List<T> list = new List<T>();
        public void AddList(T value)
        {
            list.Add(value);
        }

        public void ShowList(CollectionType<T> obj)
        {
            foreach (var item in obj.list)
            {    
                Console.WriteLine($"{item.ToString()}");
                
            }
            Console.WriteLine();

        }
    }
}

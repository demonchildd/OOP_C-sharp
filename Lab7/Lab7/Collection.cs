using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal interface Collection<T>
    {
        void AddList(T item);
        
        void ShowList();

        void DelValue(T value);
        

    }
}

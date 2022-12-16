using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    public interface ITravelAgency
    {
        ITravelAgency Clone();
        void GetInfo();
    }
}

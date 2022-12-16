using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    public class Administrator
    {
        private static Administrator instance;

        public string Name { get; private set; }
        protected Administrator(string name)
        {
            this.Name = name;
        }

        public static Administrator getInstance(string name)
        {
            if (instance == null)
                instance = new Administrator(name);
            return instance;
        }
        public bool CheckSub(Customer customer)
        {
            if (customer.GetBill() > 200)
                return false;
            else
                return true;
        }
    }
}

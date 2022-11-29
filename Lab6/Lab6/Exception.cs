using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class TextBookException : Exception
    {
        int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public TextBookException(string message, int val) : base(message)
        {
            Number = val;
        }
    }

    internal class CostException : Exception
    {
        int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public CostException(string message, int val) : base(message)
        {
            Number = val;
        }
    }

    internal class CountException : Exception
    {
        int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public CountException(string message, int val) : base(message)
        {
            Number = val;
        }
    }
}

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class StringWorker
    {
        

        string info;
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        public StringWorker(string str)
        {
            Info = str;
            
        }
        public string Delete(string str)
        { 
            str = str.Replace(".", "");
            Console.WriteLine($"{str}");
            return str;
        }
        public string Low(string str)
        {
            str = str.ToLower();
            Console.WriteLine($"{str}");
            return str;
        }

        public string Up(string str)
        {
            str = str.ToUpper();
            Console.WriteLine($"{str}");
            return str;
        }
        public string Add(string str)
        {
            string buff = Console.ReadLine();
            str = str + buff;
            Console.WriteLine($"{str}");
            return str;
        }
        public string DeleteSpace(string str)
        {
            str = str.Replace(" ", "");
            return str;
        }
        public void Information()
        {
            Console.WriteLine("Здраствуйте, Александра");
        }

        public bool Check(string str)
        {

            return str.Length > 15;
        }
    }
}

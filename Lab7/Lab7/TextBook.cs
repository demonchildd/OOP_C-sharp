using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab7
{
    internal class Textbook
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int cost;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        int countPage;
        public int CountPage
        {
            get { return countPage; }
            set { countPage = value; }
        }
        internal int forclass;

        public int ForClass
        {
            get { return forclass; }
            set { forclass = value; }
        }
        internal Textbook(string name, int cost, int countPage, int forclass)
        {
            Name = name;
            Cost = cost;
            CountPage = countPage;
            ForClass = forclass;
        }

        public override string? ToString()
        {
            return String.Format($"Name: {Name}\nCost: {Cost}\nCount: {CountPage}\nFor class: {ForClass}\n");
        }
    }
}
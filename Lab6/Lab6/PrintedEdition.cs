using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal abstract class PrintedEdition
    {
        string? name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        int cost;
        public int Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new CostException("Цена должна быть положительной", value);
                }
                else
                {
                    cost = value;
                }
            }
        }
        int countPage;
        public int CountPage
        {
            get { return countPage; }
            set
            {
                if (value <= 0)
                {
                    throw new CountException("Число страниц не может быть меньше нуля", value);
                }
                else
                {
                    cost = value;
                }
            }
        }
        public PrintedEdition(string? name, int cost, int countPage)
        {
            Name = name;
            Cost = cost;
            CountPage = countPage;
        }


        internal abstract bool Evaluation();
        internal abstract void Print();

        public override string? ToString()
        {
            Console.WriteLine($"Name: {Name}\nCost: {Cost}\nCount: {CountPage}");
            return name;
        }
        public override bool Equals(object? obj)
        {
            if (obj is PrintedEdition printed)
                return Cost == printed.Cost;
            return false;
        }
        public override int GetHashCode() => Name.GetHashCode();
    }
}

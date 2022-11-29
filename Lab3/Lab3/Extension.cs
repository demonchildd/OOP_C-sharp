using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public static class StatisticOperation
    {
        public static int Sum(this LIST lists)
        {
            int sum = 0;
            foreach (var number in lists.list)
                sum += number;
            return sum;
        }

        public static int DifferenceBetweenMaxMin(this LIST lists)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var number in lists.list)
            {
                if (number < min)
                    min = number;
                if (number > max)
                    max = number;
            }
            Console.WriteLine($"Разница между максимальным и минимальным: {max - min}");
            return 0;
        }
        public static int NumberOfElements(this LIST lists)
        {
            return lists.list.Count;
        }

        public static int MaxLen(this string str)
        {
            int len = 0;
            int max = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    len++;
                }
                else
                {
                    if (len > max)
                    {
                        max = len;
                    }
                    len = 0;
                }
            }
            return max;
        }

        public static LIST RemoveEnd(this LIST lists)
        {
            lists.list.RemoveAt(lists.list.Count - 1);
            return lists;
        }

    }
}

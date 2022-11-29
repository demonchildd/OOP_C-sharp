using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public class Ex3
    {
        public static async void ex3()
        {
            var result1 = await AddAsync(4, 5);
            var result2 = await MulAsync(4, 5);
            var result3 = await DelAsync(10, 5);
            var result4 = await SumAsync(result1, result2, result3);
            Console.WriteLine(result4);

            async Task<int> AddAsync(int a, int b)
            {
                return a + b;
            }

            async Task<int> MulAsync(int a, int b)
            {
                return a * b;
            }

            async Task<int> DelAsync(int a, int b)
            {
                return a / b;
            }

            async Task<int> SumAsync(int a, int b, int c)
            {
                return a + b + c;
            }
        }
    }
}

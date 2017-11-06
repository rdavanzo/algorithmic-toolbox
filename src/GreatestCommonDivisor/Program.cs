using System;
using System.Linq;

namespace GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constraint: 1 ≤ 𝑎, 𝑏 ≤ 2e9
            var ary = Console.ReadLine().Split()
                .Take(2)
                .Select(x => Convert.ToInt32(x))
                .ToArray();
            var a = ary[0];
            var b = ary[1];
            var result = gcd_fast(a, b);

            Console.WriteLine(result);
        }

        private static Int32 gcd_naive(Int32 a, Int32 b) 
        {
            var current_gcd = 1;
            for(var d = 2; d <= a && d <= b; ++d) 
            {
                if (a % d == 0 && b % d == 0) 
                {
                    if (d > current_gcd) 
                    {
                        current_gcd = d;
                    }
                }
            }

            return current_gcd;
        }

        private static Int32 gcd_fast(Int32 a, Int32 b)
        {
            if (b == 0)
            {
                return a;
            }

            return gcd_fast(b, a % b);
        } 
    }
}

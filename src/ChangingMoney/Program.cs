using System;

namespace ChangingMoney
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 <= m <= 10e3
            var m = Convert.ToInt32(Console.ReadLine());
            var coinCount = makeChange(m);
            Console.WriteLine(coinCount);
        }

        private static Int32 makeChange(Int32 m)
        {
            var dimeCount = m / 10;
            m = m % 10;
            if (m == 0)
            {
                return dimeCount;
            }

            var nickelCount = m / 5;
            m = m % 5;
            if (m == 0)
            {
                return dimeCount + nickelCount;
            }

            var pennyCount = m / 1;
            
            return dimeCount + nickelCount + pennyCount;
        }
    }
}

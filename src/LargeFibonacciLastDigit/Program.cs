using System;

namespace LargeFibonacciLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            //runAssertions();
            //Console.WriteLine("Assertions complete.");

            // stressTest();
            // Console.WriteLine("Stress test complete.");

            var n = Convert.ToInt32(Console.ReadLine());
            var result = hugeFibonacciFast(n);
            Console.WriteLine(result);
        }

        private static UInt64 hugeFibonacciNaive(UInt64 n)
        {
            if (n <= 1ul)
            {
                return n;
            }

            var previous = 0ul;
            var current = 1ul;
            for (var i = 0ul; i < n - 1ul; i++)
            {
                var tmp = previous;
                previous = current;
                current = tmp + current;
                //Console.WriteLine($"{current} = {tmp} + {current}");
            }
            var result = current % 10ul;
            
            return result;
        }

        private static Int32 hugeFibonacciFast(Int32 n)
        {
            if (n <= 1)
            {
                return n;
            }

            var ary = new Int32[n + 1];
            ary[0] = 0;
            ary[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                ary[i] = (ary[i - 1] + ary[i - 2]) % 10;
            }

            return ary[n];
        }

        private static void runAssertions()
        {
            var result = hugeFibonacciNaive(239ul);
            if (result != 1)
            {
                Console.WriteLine($"Wrong answer for n = 239: {result}.");
            }
        }

        private static void stressTest()
        {
            for (var n = 1; n <= 300; n++)
            {
                var slow = hugeFibonacciNaive((UInt64)n);
                var fast = hugeFibonacciFast(n);
                if (slow != (UInt64)fast)
                {
                    Console.WriteLine($"Wrong : {slow} {fast}");
                }
                else
                {
                    Console.WriteLine("Ok");
                }
            }
        }
    }
}
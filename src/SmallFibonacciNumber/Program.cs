using System;

namespace SmallFibonacciNumber
{
    class Program
    {
        private static Int32 fibonacciRecursive(Int32 n)
        {
            if (n <= 1)
            {
                return n;
            }

            return fibonacciRecursive(n - 1) + fibonacciRecursive(n - 2);
        }

        private static Int32 fibonacciIterative(Int32 n)
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
                ary[i] = ary[i - 1] + ary[i - 2];
            }

            return ary[n];
        }

        private static void runAssertions()
        {
            var a = fibonacciIterative(1);
            if (a != 1)
            {
                Console.WriteLine($"Wrong answer for n = 1: {a}.");
            }
            
            var b = fibonacciIterative(2);
            if (b != 1)
            {
                Console.WriteLine($"Wrong answer for n = 2: {b}.");
            } 

            var c = fibonacciIterative(10);
            if (c != 55)
            {
                Console.WriteLine($"Wrong answer for n = 10: {c}.");
            }
        }

        private static void stressTest()
        {
            for (var n = 1; n <= 20; n++)
            {
                var slow = fibonacciRecursive(n);
                var fast = fibonacciIterative(n);
                if (slow != fast)
                {
                    Console.WriteLine($"Wrong : {slow} {fast}");
                }
                else
                {
                    Console.WriteLine("Ok");
                }
            }
        }

        static void Main(string[] args)
        {
            // runAssertions();
            // Console.WriteLine("Assertions complete.");

            // stressTest();
            // Console.WriteLine("Stress test complete.");

            var n = Convert.ToInt32(Console.ReadLine());
            var smallFibNumber = fibonacciIterative(n);
            Console.WriteLine(smallFibNumber);
        }
    }
}

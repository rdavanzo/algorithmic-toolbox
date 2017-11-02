using System;
using System.Linq;
using System.Collections.Generic;

namespace MaxPairwiseProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            //stressTest();
             
            var n = Convert.ToInt64(Console.ReadLine());
            var ary = Console.ReadLine().Split().Select(x => Convert.ToInt64(x)).ToArray();
            var result = maxPairwiseProductFaster(ary);
            Console.WriteLine(result);
        }

        private static void stressTest()
        {
            while (true)
            {
                // Generate a new array size.
                var n = new Random().Next(2, 1000);
                Console.WriteLine(n);

                // Build a list of numbers for our test and output them to the console.
                var list = new List<Int64>();
                for (var i = 0; i < n; i++)
                {
                    var next = new Random().Next(0, 99999);
                    list.Add(next);
                }
                var sb = new System.Text.StringBuilder();
                foreach (var i in list)
                {
                    sb.Append(i + " ");
                }
                var aryOutput = sb.ToString().TrimEnd();
                Console.WriteLine(aryOutput);
                
                // Test both implementations.
                var ary = list.ToArray();
                var res1 = maxPairwiseProduct(ary);
                var res2 = maxPairwiseProductFaster(ary);
                if (res1 != res2)
                {
                    Console.WriteLine("Error mismatch: " + res1 + " != " + res2);
                    break;
                }
                else
                {
                    Console.WriteLine("Ok");
                }
            }
        }

        private static Int64 maxPairwiseProduct(Int64[] a)
        {
            var result = 0L;

            var n = a.Length;
            for (var i = 0L; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (a[i] * a[j] > result)
                    {
                        result = a[i] * a[j];
                    }
                }
            }

            return result;
        }

        private static Int64 maxPairwiseProductFaster(Int64[] ary)
        {
            var result = 0L;
            var n = ary.Length;

            var idx1 = -1L;
            for (var i = 0L; i < n; i++)
            {
                if (idx1 == -1 || ary[i] > ary[idx1])
                {
                    idx1 = i;
                } 
            }          

            var idx2 = -1L;
            for (var j = 0L; j < n; j++)
            {
                if (j != idx1 && (idx2 == -1 || ary[j] > ary[idx2]))
                {
                    idx2 = j;
                } 
            }          

            result = ary[idx1] * ary[idx2];

            return result;
        }
    }
}

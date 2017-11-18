using System;
using System.Linq;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        /*
        Input Format. The first line of the input contains an integer 𝑛 and a sequence 𝑎0 < 𝑎1 < . . . < 𝑎𝑛−1 of
        𝑛 pairwise distinct positive integers in increasing order. The next line contains an integer 𝑘 and 𝑘
        positive integers 𝑏0, 𝑏1, . . . , 𝑏𝑘−1.

        Constraints. 1 ≤ 𝑛, 𝑘 ≤ 10^5; 1 ≤ 𝑎𝑖 ≤ 10^9 for all 0 ≤ 𝑖 < 𝑛; 1 ≤ 𝑏𝑗 ≤ 10^9 for all 0 ≤ 𝑗 < 𝑘;
        
        Output Format. For all 𝑖 from 0 to 𝑘 − 1, output an index 0 ≤ 𝑗 ≤ 𝑛 − 1 such that 𝑎𝑗 = 𝑏𝑖 or −1 if there
        is no such index.
         */
        static void Main(string[] args)
        {
            var list1 = Console.ReadLine().Split().Select(s => Convert.ToInt32(s));
            var list2 = Console.ReadLine().Split().Select(s => Convert.ToInt32(s));
            //var list2 = new List<Int32>() {5,8,1,23,1,11};
            //var list1 = new List<Int32>() {5,1,5,8,12,13};
            var n = list1.First();
            var source = list1.Skip(1).Take(n).ToArray();
            var k = list2.First();
            var keys = list2.Skip(1).Take(k).ToArray();

            for (int i = 0; i < k; i++) 
            {
                Console.Write(binarySearchIterative(source, 0, source.Length - 1, keys[i]) + " ");
            }
        }

        static int binarySearchIterative(int[] a, int low, int high, int x)
        {
            while (low <= high)
            {
                var mid = low + ((high - low) / 2);
                if (a[mid] == x)
                {
                    return mid;
                }  
                else if (x < a[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        static int binarySearchRecursive(int[] a, int low, int high, int x)
        {
            if (high < low)
            {
                return -1;
            }

            var mid = low + ((high - low) / 2);
            if (x == a[mid])
            {
                return mid;
            }
            if (x < a[mid])
            {
                return binarySearchRecursive(a, low, mid - 1, x);
            }
            
            return binarySearchRecursive(a, mid + 1, high, x);
        }

        static int linearSearch(int[] a, int x) 
        {
            for (int i = 0; i < a.Length; i++) 
            {
                if (a[i] == x) return i;
            }
           
            return -1;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace ImprovingQuickSort
{
    class Program
    {
        /*
        Input Format. The first line of the input contains an integer 𝑛. The next line contains a sequence of 𝑛
        integers 𝑎0, 𝑎1, . . . , 𝑎𝑛−1.
        
        Constraints. 1 ≤ 𝑛 ≤ 105; 1 ≤ 𝑎𝑖 ≤ 109 for all 0 ≤ 𝑖 < 𝑛.
        
        Output Format. Output this sequence sorted in non-decreasing order.
        */
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(s => Convert.ToInt32(s)).ToArray();
            
            //var n = 4;
            //var a = new [] {2,1,1,0};
            // var n = 10;
            // var a = new [] {7,4,1,9,1,3,8,4,2,0};

            // var list = new List<int>();
            // var rand = new System.Random(2);
            // var n = 10;
            // for (int i = 0; i < n; i++)
            // {
            //     var j = rand.Next(10);
            //     list.Add(j);
            //     Console.Write(j + " ");
            // }
            // var a = list.ToArray();
            // Console.WriteLine();
            
            randomizedQuickSort(a, 0, n - 1);
            for (int i = 0; i < n; i++) 
            {
                Console.Write(a[i] + " ");
            }
        }

        private static int[] partition3(int[] a, int l, int r) 
        {
            int x = a[l];
            int m1 = l;
            int m2 = l;
            for (int i = l + 1; i <= r; i++) 
            {
                if (a[i] < x)
                {
                    m1++;
                    m2++;
                    swap(a, i, m1 - 1);
                }
                else if (a[i] == x)
                {
                    m2++;
                    swap(a, i, m2); 
                }
            }
            swap(a, l, m1);
            int[] m = {m1, m2};

            return m;
        }

        private static int partition2(int[] a, int l, int r) 
        {
            int x = a[l];
            int j = l;
            for (int i = l + 1; i <= r; i++) 
            {
                if (a[i] <= x) 
                {
                    j++;
                    swap(a, i, j);
                }
            }
            swap(a, l, j);

            return j;
        }

        private static void randomizedQuickSort(int[] a, int l, int r) 
        {
            if (l >= r) 
            {
                return;
            }

            int k = new System.Random().Next(r - l + 1) + l;
            swap(a, l, k);

            // int m = partition2(a, l, r);
            // randomizedQuickSort(a, l, m - 1);
            // randomizedQuickSort(a, m + 1, r);

            int[] m = partition3(a, l, r);
            randomizedQuickSort(a, l, m[0] - 1);
            randomizedQuickSort(a, m[1] + 1, r);
        }

        private static void swap(int[] a, int source, int target)
        {
            int temp = a[source];
            a[source] = a[target];
            a[target] = temp;
        }
    }
}

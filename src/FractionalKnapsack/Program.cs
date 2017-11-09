using System;
using System.Collections.Generic;

namespace FractionalKnapsack
{
    class Program
    {
        /*
        Input Format. The first line of the input contains the number 𝑛 of items and the capacity 𝑊 of a knapsack.
        The next 𝑛 lines define the values and weights of the items. The 𝑖-th line contains integers 𝑣𝑖 and 𝑤𝑖—the
        value and the weight of 𝑖-th item, respectively.

        Constraints. 1 ≤ 𝑛 ≤ 1e3, 0 ≤ 𝑊 ≤ 2 · 1e6; 0 ≤ 𝑣𝑖 ≤ 2 · 1e6, 0 < 𝑤𝑖 ≤ 2 · 1e6 for all 1 ≤ 𝑖 ≤ 𝑛. All the
        numbers are integers.

        Output Format. Output the maximal value of fractions of items that fit into the knapsack. The absolute
        value of the difference between the answer of your program and the optimal value should be at most
        10e−3. To ensure this, output your answer with at least four digits after the decimal point (otherwise
        your answer, while being computed correctly, can turn out to be wrong because of rounding issues).
         */
        static void Main(string[] args)
        {
            var ary = Console.ReadLine().Split();
            var numItems = Convert.ToInt32(ary[0]);
            var capacity = Convert.ToInt32(ary[1]);

            var values = new Int32[numItems];
            var weights = new Int32[numItems];
            for (var i = 0; i < numItems; i++)
            {
                ary = Console.ReadLine().Split();
                values[i] = Convert.ToInt32(ary[0]);
                weights[i] = Convert.ToInt32(ary[1]);
            } 
            // var capacity = 50;
            // var values = new [] {60,100,120};
            // var weights = new [] {20,50,30};

            var result = fractionalKnapsackOptimized(capacity, values, weights);
            Console.WriteLine(result);
        }

        private static Double fractionalKnapsackOptimized(Int32 capacity, Int32[] values, Int32[] weights)
        {
            Double value = 0D;

            var items = getSortedItems(values, weights);
            foreach (var item in items)
            {
                if (capacity == 0)
                {
                    break;
                }
                var amountToAdd = Math.Min(item.Weight, capacity);
                value = value + (Double)amountToAdd * item.PerItemValue;
                capacity = capacity - amountToAdd;
            }

            return Math.Round(value, 4);
        }

        private static List<ItemInfo> getSortedItems(Int32[] values, Int32[] weights) 
        {
            var nfos = new List<ItemInfo>(values.Length);
            for (var i = 0; i < values.Length; i++)
            {
                nfos.Add(new ItemInfo(values[i], weights[i]));
            }
            nfos.Sort(Comparer<ItemInfo>.Create((a, b) => b.PerItemValue.CompareTo(a.PerItemValue)));

            return nfos;
        }

        private struct ItemInfo
        {
            public ItemInfo(Int32 value, Int32 weight)
            {
                Value = value;
                Weight = weight;
                PerItemValue = (Double)value / (Double)weight;
            }

            public Int32 Value { get; }

            public Int32 Weight { get; }

            public Double PerItemValue { get; }
        }

        private static Double fractionalKnapsack(Int32 capacity, Int32[] values, Int32[] weights)
        {
            Double value = 0D;

            var n = values.Length;
            for (var i = 0; i < n; i++)
            {
                // The knapsack is full.
                if (capacity == 0)
                {
                    break;
                }
                
                // Find the index of the item with the highest per unit value.
                var maxPerUnitValue = 0D;
                var maxPerUnitValueIdx = 0;
                for (var j = 0; j < n; j++)
                {
                    // Skip if there is no more of this item left to add.
                    if (weights[j] == 0)
                    {
                        break;
                    }

                    var perUnitValue = (Double)values[j] / (Double)weights[j];
                    if (perUnitValue > maxPerUnitValue)
                    {
                        maxPerUnitValue = perUnitValue;
                        maxPerUnitValueIdx = j;
                    }
                }

                // Now that we have the item with the greatest per unit value, determine how much 
                // we can add to the knapsack based on its current capacity.
                var amountToAdd = Math.Min(weights[maxPerUnitValueIdx], capacity);

                // Update the value of items in the knapsack.
                value = value + amountToAdd * maxPerUnitValue;
                
                // Reduce the capacity and amount of the item for the next iteration.
                capacity = capacity - amountToAdd;
                weights[maxPerUnitValueIdx] = weights[maxPerUnitValueIdx] - amountToAdd;
            }

            return Math.Round(value, 4);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    public class KnapsackResolver
    {
        public Knapsack GetHighestValue(int maxWeight, IEnumerable<Item> items)
        {
            // initialize series
            Dictionary<int, Knapsack> primaryTable = new();
            foreach (Item item in items)
            {
                int iterations = (int) Math.Floor(maxWeight / (double) item.Weight);
                for (int i = 0; i < iterations; i++)
                {
                    int amount = i + 1;
                    ItemSet set = new(item, amount);
                    Knapsack knapsack = KnapsackFactory.CreatePrimary(new[] {set});
                    primaryTable[knapsack.TotalWeight] = knapsack;
                }
            }

            // combination phase
            for (int x = 0; x < primaryTable.Count; x++)
            {
                (_, Knapsack left) = primaryTable.ElementAt(x);
                for (int y = x + 1; y < primaryTable.Count; y++)
                {
                    (_, Knapsack right) = primaryTable.ElementAt(y);

                    if (left.TotalWeight + right.TotalWeight > maxWeight)
                        continue;

                    Knapsack combined = KnapsackFactory.Combine(left, right);

                    // check existing
                    if (primaryTable.ContainsKey(combined.TotalWeight))
                    {
                        Knapsack existing = primaryTable[combined.TotalWeight];
                        if (combined.TotalValue > existing.TotalValue)
                        {
                            primaryTable[combined.TotalWeight] = combined;
                        }

                        continue;
                    }

                    // add
                    primaryTable[combined.TotalWeight] = combined;
                }
            }

            // return the highest value
            return primaryTable.Values.OrderByDescending(x => x.TotalValue).First();
        }
    }
}
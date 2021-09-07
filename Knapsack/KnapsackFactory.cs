using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    public static class KnapsackFactory
    {
        public static Knapsack CreatePrimary(ItemSet[] content)
        {
            return CreatePrimary(content.ToList());
        }

        public static Knapsack CreatePrimary(List<ItemSet> content)
        {
            return new Knapsack(content);
        }

        public static Knapsack Combine(Knapsack left, Knapsack right)
        {
            if (left is null || right is null)
            {
                throw new ArgumentNullException(null, $"left and right must be not null");
            }
            return new Knapsack(left.Content.Concat(right.Content).ToList());
        }
    }
}

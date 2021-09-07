using System;
using System.Collections.Generic;
using Xunit;

namespace Knapsack.Test
{
    public class KnapsackFactoryTests
    {
        [Fact]
        public void CreatePrimaryKnapsack()
        {
            Item item = new Item(10, 20);
            Item secondItem = new Item(15, 30);

            ItemSet[] content = new[]
            {
                new ItemSet(item, 1),
                new ItemSet(secondItem, 4)
            };

            Knapsack knapsack = KnapsackFactory.CreatePrimary(content);
            
            Assert.NotNull(knapsack);
            Assert.NotNull(knapsack.Content);
        }

        [Fact]
        public void NullExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => KnapsackFactory.CreatePrimary((ItemSet[]) null));
            Assert.Throws<ArgumentNullException>(() => KnapsackFactory.CreatePrimary((List<ItemSet>)null));
            Assert.Throws<ArgumentNullException>(() => KnapsackFactory.Combine(null, null));
        }
    }
}
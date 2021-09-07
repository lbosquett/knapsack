using System.Linq;
using Xunit;

namespace Knapsack.Test
{
    public class WeightTests
    {
        [Fact]
        public void GetSomeWeight()
        {
            Item[] items = new[]
            {
                new Item(20, 10),
                new Item(25, 15)
            };
            
            KnapsackResolver resolver = new KnapsackResolver();
            Knapsack result = resolver.GetHighestValue(20, items);

            var content = result.Content;
            
            Assert.NotNull(content);
            Assert.NotEmpty(content);

            foreach (ItemSet set in content)
            {
                Assert.True(set.Amount > 0, "amount must be greater than 0");
                Assert.NotNull(set.Item);
                
                Assert.True(set.TotalWeight > 0, "weight must be greater than 0");
            }
        }

        [Fact]
        public void GetLessWeight()
        {
            Item[] items = new[]
            {
                // same value, different weights
                new Item(5, 20) { Tag = "heavy" },
                new Item(3, 20) { Tag = "light" }
            };

            KnapsackResolver resolver = new KnapsackResolver();
            Knapsack result = resolver.GetHighestValue(15, items);

            var content = result.Content;
            
            Assert.Single(content, "should generate 1 set");

            ItemSet set = content.First();
            Assert.Equal(3, set.Item.Weight);
            Assert.Equal("light", set.Item.Tag);
        }
    }
}
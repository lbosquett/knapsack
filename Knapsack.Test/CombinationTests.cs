using System.Linq;
using Xunit;

namespace Knapsack.Test
{
    public class CombinationTests
    {
        [Fact]
        public void TrickTest()
        {
            Item[] items = new[]
            {
                new Item(100, 20),
                new Item(30, 20),
            };

            KnapsackResolver resolver = new KnapsackResolver();
            Knapsack result = resolver.GetHighestValue(120, items);

            Assert.Single(result.Content);

            var content = result.Content;

            ItemSet set = content.First();
            Assert.Equal(4, set.Amount);
            Assert.Equal(30, set.Item.Weight);
            Assert.Equal(120, set.TotalWeight);
        }
    }
}
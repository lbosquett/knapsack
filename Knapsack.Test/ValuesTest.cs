using System.Linq;
using Xunit;

namespace Knapsack.Test
{
    public class ValuesTest
    {
        [Fact]
        public void GetHighestValue()
        {
            Item[] items = new[]
            {
                new Item(5, 10) {Tag = "less-value"},
                new Item(5, 15) {Tag = "more-value"}
            };

            KnapsackResolver resolver = new KnapsackResolver();
            Knapsack knapsack = resolver.GetHighestValue(20, items);

            var content = knapsack.Content;

            Assert.Single(content);

            var set = content.First();

            Assert.Equal("more-value", set.Item.Tag);
        }
    }
}
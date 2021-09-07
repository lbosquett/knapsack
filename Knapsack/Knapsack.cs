using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    public class Knapsack
    {
        public List<ItemSet> Content { get; }
        
        public int TotalWeight { get; }
        
        public int TotalValue { get; }

        public Knapsack(List<ItemSet> content)
        {
            Content = content;
            TotalWeight = Content.Select(x => x.TotalWeight).Sum();
            TotalValue = Content.Select(x => x.TotalValue).Sum();
        }
    }
}
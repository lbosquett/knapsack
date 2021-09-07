namespace Knapsack
{
    public record ItemSet
    {
        public Item Item { get; }

        public int Amount { get; }

        public int TotalWeight { get; }

        public int TotalValue { get; }

        public ItemSet(Item item, int amount)
        {
            Item = item;
            Amount = amount;

            TotalWeight = item.Weight * amount;
            TotalValue = item.Value * amount;
        }
    }
}
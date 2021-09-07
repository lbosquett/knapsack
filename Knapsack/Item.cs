namespace Knapsack
{
    public class Item
    {
        public object Tag { get; set; }

        public int Weight { get; }

        public int Value { get; }

        public Item(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }
    }
}
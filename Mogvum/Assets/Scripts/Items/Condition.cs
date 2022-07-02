using Assets.Scripts.Utilities;

namespace Assets.Scripts.Items
{
    public class Condition : BarValue
    {
        private Item Item { get; set; }

        public Condition(Item item)
        {
            Item = item;
        }

        public Condition(Item item, int value) : base(value)
        {
            Item = item;
        }

        public Condition(Item item, decimal percent, int max) : base(percent, max)
        {
            Item = item;
        }

        public Condition(Item item, int current, int max) : base(current, max)
        {
            Item = item;
        }
    }
}

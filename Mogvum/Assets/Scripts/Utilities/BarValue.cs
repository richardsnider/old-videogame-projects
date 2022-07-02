namespace Assets.Scripts.Utilities
{
    /// <summary>
    /// Represents values with a current and maximum. Can also be accessed as a percent.
    /// </summary>
    public class BarValue
    {
        protected int current;
        public int Current
        {
            get { return current; }
            set
            {
                if (value <= 0) current = 0;
                else if (value >= Max) current = Max;
            }
        }

        protected int max;
        public int Max
        {
            get { return max; }
            set
            {
                if (value <= 0) current = max = 0;
                else if (value <= current) current = max = value;
            }
        }

        /// <summary>
        /// Represents current / max as a decimal. Value can only range from 0 to 1. Current value will be set to a rounded decimal representation.
        /// </summary>
        public decimal Percent
        {
            get { return (decimal)current / max; }
            set
            {
                if (value >= 1) current = max;
                else if (value <= 0) current = 0;
                else current = (int)decimal.Round(max * value);
            }
        }

        public BarValue() : this((int)Values.Bar) { }
        public BarValue(int value) : this(value, value) { }
        public BarValue(int current, int max)
        {
            Max = max;
            Current = current;
       }

        public BarValue(decimal percent, int max)
        {
            Max = max;
            Percent = percent;
        }
    }
}
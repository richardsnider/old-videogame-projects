using Assets.Scripts.Utilities;

namespace Assets.Scripts.Characters
{
    public class Encumbrance : BarValue
    {
        public Encumbrance()
        {
        }

        public Encumbrance(int value) : base(value)
        {
        }

        public Encumbrance(decimal percent, int max) : base(percent, max)
        {
        }

        public Encumbrance(int current, int max) : base(current, max)
        {
        }
    }
}

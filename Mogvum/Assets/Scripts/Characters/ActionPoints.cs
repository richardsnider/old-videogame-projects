using Assets.Scripts.Utilities;

namespace Assets.Scripts.Characters
{
    public class ActionPoints : BarValue
    {
        public Character Character { get; set; }

        public ActionPoints(Character character)
        {
            Character = character;
        }

        public ActionPoints(Character character, int value) : base(value)
        {
            Character = character;
        }

        public ActionPoints(Character character, decimal percent, int max) : base(percent, max)
        {
            Character = character;
        }

        public ActionPoints(Character character, int current, int max) : base(current, max)
        {
            Character = character;
        }
    }
}

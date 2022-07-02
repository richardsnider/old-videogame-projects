using Assets.Scripts.Utilities;

namespace Assets.Scripts.Characters.BodyParts
{
    public class BodyPartStatus : BarValue
    {
        protected BodyPart BodyPart { get; set; }

        public BodyPartStatus(BodyPart bodyPart)
        {
            BodyPart = bodyPart;
        }

        public BodyPartStatus(BodyPart bodyPart, int value) : base(value)
        {
            BodyPart = bodyPart;
        }

        public BodyPartStatus(BodyPart bodyPart, decimal percent, int max) : base(percent, max)
        {
            BodyPart = bodyPart;
        }

        public BodyPartStatus(BodyPart bodyPart, int current, int max) : base(current, max)
        {
            BodyPart = bodyPart;
        }
    }
}

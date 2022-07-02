namespace Assets.Scripts.Characters.BodyParts
{
    public class Energy : BodyPartStatus
    {
        public Energy(BodyPart bodyPart) : base(bodyPart)
        {
        }

        public Energy(BodyPart bodyPart, int value) : base(bodyPart, value)
        {
        }

        public Energy(BodyPart bodyPart, int current, int max) : base(bodyPart, current, max)
        {
        }

        public Energy(BodyPart bodyPart, decimal percent, int max) : base(bodyPart, percent, max)
        {
        }

        public new int Current
        {
            get { return base.Current; }
            set
            {
                if (base.Current - value >= base.Current)
                    BodyPart.Life.Current -= (value - base.Current);

                base.Current = value;
            }
        }


    }
}
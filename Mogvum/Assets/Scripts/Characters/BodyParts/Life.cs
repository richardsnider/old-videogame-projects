namespace Assets.Scripts.Characters.BodyParts
{
    public class Life : BodyPartStatus
    {
        public Life(BodyPart bodyPart) : base(bodyPart)
        {
        }

        public Life(BodyPart bodyPart, int value) : base(bodyPart, value)
        {
        }

        public Life(BodyPart bodyPart, int current, int max) : base(bodyPart, current, max)
        {
        }

        public Life(BodyPart bodyPart, decimal percent, int max) : base(bodyPart, percent, max)
        {
        }

        public new int Current
        {
            get { return base.Current;  }
            set
            {
                base.Current = value;
                if(base.Current == 0) BodyPart.Destroy();
            }
        }
    }
}

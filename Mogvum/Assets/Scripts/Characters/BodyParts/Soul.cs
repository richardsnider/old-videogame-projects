namespace Assets.Scripts.Characters.BodyParts
{
    public class Soul : BodyPartStatus
    {
        public Soul(BodyPart bodyPart) : base(bodyPart)
        {
        }

        public Soul(BodyPart bodyPart, int value) : base(bodyPart, value)
        {
        }

        public Soul(BodyPart bodyPart, decimal percent, int max) : base(bodyPart, percent, max)
        {
        }

        public Soul(BodyPart bodyPart, int current, int max) : base(bodyPart, current, max)
        {
        }
    }
    
}
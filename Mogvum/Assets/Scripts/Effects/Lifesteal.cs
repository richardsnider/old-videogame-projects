using System;
using System.Collections.Generic;
using Assets.Scripts.Characters;

namespace Assets.Scripts.Effects
{
    public class LifeSteal : Effect<Character>
    {
        private int Amount { get; set; }
        private int Duration { get; set; }
        new Character Source { get; set; }

        protected LifeSteal(Character source, Character target, int amount = 0, int duration = 1)
            : base(source, target)
        {
            Source = source;
            Amount = amount;
            Duration = duration;

            Conditions.Add(() => Duration > 0);
        }

        public new void Apply()
        {
            foreach (var bodyPart in Source.Anatomy.BodyParts)
                bodyPart.Life.Current += Amount;

            foreach (var bodyPart in Target.Anatomy.BodyParts)
                bodyPart.Life.Current -= Amount;

            Duration--;
            Validate();
        }
    }
}

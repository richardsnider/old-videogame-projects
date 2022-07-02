using System;
using System.Diagnostics.CodeAnalysis;

namespace Assets.Scripts.Characters
{
    [Serializable]
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")]
    public class Skill
    {
        public static int DecayRate { get; set; }

        public Character Character { get; private set; }

        public Skill(Character character)
        {
            Character = character;
        }

        public SkillLevel Alchemy { get { return Horticulture + BasicAlchemy + Poisoning + Cooking; } }
        public SkillLevel Horticulture { get; set; }
        public SkillLevel BasicAlchemy { get; set; }
        public SkillLevel Poisoning { get; set; }
        public SkillLevel Cooking { get; set; }

        public SkillLevel Arcana { get { return BasicArcana + Holy + Shadow + Nature + Chaos; } }
        public SkillLevel BasicArcana { get; set; }
        public SkillLevel Holy { get; set; }
        public SkillLevel Shadow { get; set; }
        public SkillLevel Nature { get; set; }
        public SkillLevel Chaos { get; set; }

        public SkillLevel Sorcery {  get { return BasicSorcery + Fire + Water + Wind + Earth + Lightning; } }
        public SkillLevel BasicSorcery { get; set; }
        public SkillLevel Fire { get; set; }
        public SkillLevel Water { get; set; }
        public SkillLevel Wind { get; set; }
        public SkillLevel Earth { get; set; }
        public SkillLevel Lightning { get; set; }

        public SkillLevel Crafstmanship { get { return BasicCraftsmanship + Architecture + Carpentry + Tailoring; } }
        public SkillLevel BasicCraftsmanship { get; set; }
        public SkillLevel Tailoring { get; set; }
        public SkillLevel Architecture { get { return Carpentry + Masonry; } }
        public SkillLevel Carpentry { get; set; }
        public SkillLevel Masonry { get; set; }
        public SkillLevel Metallurgy { get; set; }
        public SkillLevel Mechanics { get; set; }

        public SkillLevel Disarming { get; set; }
        public SkillLevel LockPicking { get; set; }

        public SkillLevel Kinesis { get { return Balance + Contortion + Acrobatics + Climbing; }}
        public SkillLevel Running { get; set; }
        public SkillLevel Flying { get; set; }
        public SkillLevel Swimming { get; set; }
        public SkillLevel Balance { get; set; }
        public SkillLevel Contortion { get; set; }
        public SkillLevel Acrobatics { get; set; }
        public SkillLevel Climbing { get; set; }

        public SkillLevel Melee { get { return BasicMelee + Blade + Axe + PoleArm + Hammer + DoubleEnded + Whip + Shield; } }
        public SkillLevel BasicMelee { get; set; }
        public SkillLevel Blade { get; set; }
        public SkillLevel Axe { get; set; }
        public SkillLevel PoleArm { get; set; }
        public SkillLevel Hammer { get; set; }
        public SkillLevel DoubleEnded { get; set; }
        public SkillLevel Whip { get; set; }
        public SkillLevel Shield { get; set; }

        public SkillLevel Ranged { get { return Aim + Throwing + Archery; } }
        public SkillLevel Aim { get; set; }
        public SkillLevel Throwing { get; set; }
        public SkillLevel Archery { get; set; }

        public SkillLevel Persuasion { get {return BasicPersuasion + Intimidation + Charm + Demoralize + Encourage + Antagonize; } }
        public SkillLevel BasicPersuasion { get; set; }
        public SkillLevel Intimidation { get; set; }
        public SkillLevel Charm { get; set; }
        public SkillLevel Demoralize { get; set; }
        public SkillLevel Encourage { get; set; }
        public SkillLevel Antagonize { get; set; }
        public SkillLevel Language { get; set; }
        public SkillLevel Haggling { get; set; }

        public SkillLevel Taming { get; set; }
        public SkillLevel Riding { get; set; }

        public SkillLevel Disguise {get { return Persuasion + Stealth; } }
        public SkillLevel Stealth { get; set; }

        public SkillLevel Perception { get; set; }
        public SkillLevel Tracking { get; set; }
    }
}

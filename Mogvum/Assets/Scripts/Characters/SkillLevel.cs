using System;

namespace Assets.Scripts.Characters
{
    public class SkillLevel
    {
        public Skill Skill { get; private set; }
        public uint Level { get; set; }

        /// <summary>
        /// Indicates the last day in game history that the skill was utilized.
        /// </summary>
        public uint LastTrained { get; set; }

        public SkillLevel(Skill skill)
        {
            Skill = skill;
        }

        public void Train(uint amount)
        {
            Level += amount;
            LastTrained = Skill.Character.Cube.Region.World.Date;
        }

        public void Decay()
        {
            Level -= (uint) Skill.DecayRate*(Skill.Character.Cube.Region.World.Date - LastTrained);
        }

        public static SkillLevel operator+(SkillLevel a, SkillLevel b)
        {
            return new SkillLevel(a.Skill)
            {
                Level = a.Level + b.Level,
                LastTrained = Math.Max(a.LastTrained, b.LastTrained)
            };
        }
    }
}

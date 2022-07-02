using System;
using System.Collections.Generic;
using Assets.Scripts.Abilities;
using Assets.Scripts.Effects;
using Assets.Scripts.Regions;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class Character : IEffectSource, IEffectTarget<Character>
    {
        public RegionCube Cube { get; private set; }
        public CharacterTitles Titles { get; private set; }
        public Allegiance Allegiance { get; private set; }
        public CharacterType Type { get; private set; }
        public Anatomy Anatomy { get; private set; }
        public Skill Skill { get; private set; }
        public ActionPoints ActionPoints { get; private set; }

        public Character(RegionCube cube, CharacterTitles titles = null, Allegiance allegiance = null, CharacterType type = null,
           Anatomy anatomy = null, Skill skill = null, ActionPoints actionPoints = null)
        {
            Cube = cube;
            Titles = titles ?? new CharacterTitles();
            Allegiance = allegiance ?? new Allegiance(this);
            Type = type ?? new CharacterType(this);
            Anatomy = anatomy ?? new Anatomy(this);
            Skill = skill ?? new Skill(this);
            ActionPoints = actionPoints ?? new ActionPoints(this);
        }

        public void Destroy()
        {
            Cube.RemoveOccupant(this);
        }

        public ICollection<IEffect<Character>> Effects { get; set; }
        public void AddEffect(IEffect<Character> effect)
        {
            throw new NotImplementedException();
        }

        public void RemoveEffect(IEffect<Character> effect)
        {
            throw new NotImplementedException();
        }

        public void AttemptAbility(IAbility ability)
        {
            
        }
    }
}

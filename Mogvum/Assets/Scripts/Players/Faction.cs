using System;
using System.Collections.Generic;
using Assets.Scripts.Characters;

namespace Assets.Scripts.Players
{
    [Serializable]
    public class Faction
    {
        private World World { get; set; }
        public string Name { get; private set; }
        public ICollection<Character> Characters { get; private set; }

        public Faction(World world, string name = null, ICollection<Character> characters = null)
        {
            World = world;
            Name = name ?? Utilities.NameGenerator.CreateNames()[1];
            Characters = characters ?? new List<Character>();
        }

        public void AddCharacter(Character character)
        {
            if(!Characters.Contains(character))
                Characters.Add(character);
        }
    }
}

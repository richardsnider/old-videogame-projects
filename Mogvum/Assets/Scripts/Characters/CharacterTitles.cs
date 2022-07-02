using System;
using System.Collections.Generic;
using System.Linq;
namespace Assets.Scripts.Characters
{
    [Serializable]
    public class CharacterTitles
    {
        public ICollection<string> FirstNames { get; private set; }
        public ICollection<string> LastNames { get; private set; }
        public ICollection<string> Prefixes { get; private set; }
        public ICollection<string> Suffixes { get; private set; }

        public CharacterTitles(ICollection<string> firstNames = null, ICollection<string> lastNames = null, ICollection<string> prefixes = null, ICollection<string> suffixes = null )
        {
            FirstNames = firstNames ?? new List<string>();
            LastNames = lastNames ?? new List<string>();
            Prefixes = prefixes ?? new List<string>();
            Suffixes = suffixes ?? new List<string>();
        }

        public string Default
        {
            get { return FirstNames.FirstOrDefault() + LastNames.FirstOrDefault(); }
        }
    }
}

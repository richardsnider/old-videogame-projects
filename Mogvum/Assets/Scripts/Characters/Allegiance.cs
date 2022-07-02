using System;
using System.Collections.Generic;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class Allegiance
    {
        private Character Character { get; set; }
        private IDictionary<Guid, int> FactionLoyalty { get; set; }
        private int contentment;

        public Allegiance(Character character)
        {
            Character = character;
            FactionLoyalty = new Dictionary<Guid, int>();
        }

        public int GetAllegiance(Guid factionName)
        {
            return FactionLoyalty[factionName];
        }

        public int GetContentment()
        {
            return contentment;
        }

        public void IncrementAllegiance(Guid factionName, int value)
        {
            FactionLoyalty[factionName] += value;
        }

        public void IncrementContentment(int value)
        {
            contentment += value;
        }

        public void DecrementAllegiance(Guid factionName, int value)
        {
            FactionLoyalty[factionName] -= value;
        }

        public void DecrementContentment(int value)
        {
            contentment -= value;
        }
    }
}

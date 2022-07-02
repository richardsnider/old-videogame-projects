using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Characters;
using Assets.Scripts.Effects;
using Assets.Scripts.Items;

namespace Assets.Scripts.Regions
{
    [Serializable]
    public class RegionCube : IHasInventory, IEffectTarget<RegionCube>
    {
        public Region Region { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public Matter Matter { get; private set; }

        public ICollection<Character> Occupants { get; private set; }
        public Inventory Inventory { get; private set; }
        public int Cover { get; private set; }
        public int Lighting { get; private set; }

        public bool IsTraversable
        {
            get { return Matter == Matter.Air && !Occupants.Any(); }
        }

        public RegionCube(Region region, int x, int y, int z, Matter matter = Matter.Vacuum,
            ICollection<Character> occupants = null, Inventory inventory = null, int cover = 0, int lighting = 100)
        {
            Region = region;
            X = x;
            Y = y;
            Z = z;
            Matter = matter;
            Occupants = occupants ?? new List<Character>();
            Inventory = inventory ?? new Inventory(this);
            Cover = cover;
            Lighting = lighting;
        }

        public bool AddOccupant(Character character)
        {
            if ((character.Anatomy.Size <= CharacterSize.Tiny || Occupants.Count == 0)
                && !Occupants.Contains(character))
            {
                Occupants.Add(character);
                return true;
            }

            return false;
        }

        public Character RemoveOccupant(Character character)
        {
            if (Occupants.Contains(character))
            {
                Occupants.Remove(character);
                return character;
            }

            return null;
        }

        public RegionCube Cube
        {
            get { return this; }
        }

        public ICollection<IEffect<RegionCube>> Effects { get; set; }
        public void AddEffect(IEffect<RegionCube> effect)
        {
            throw new NotImplementedException();
        }

        public void RemoveEffect(IEffect<RegionCube> effect)
        {
            throw new NotImplementedException();
        }
    }
}

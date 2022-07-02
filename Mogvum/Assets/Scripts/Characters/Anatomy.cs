using System.Collections.Generic;
using Assets.Scripts.Characters.BodyParts;

namespace Assets.Scripts.Characters
{
    public class Anatomy
    {
        public Character Character { get; private set; }

        //Strength affects MaxLife, MaxCarryWeight, and melee/ranged abilities.
        //It is determined by an energy usage to Encumbrance ratio.
        public int Strength { get; private set; }
        //Vitality affects LifeRegen, MaxEnergy, and EnergyRegen.
        //It is determined by energy usage.
        public int Vitality { get; private set; }

        public bool IsRespiratory { get; set; }
        public bool IsAquatic { get; set; }
        public Encumbrance Encumbrance { get; set; }
        public CharacterSize Size { get; private set; }
        public ICollection<BodyPart> BodyParts { get; private set; }

        public Anatomy(Character character, int strength = 0, int vitality = 0, Encumbrance encumbrance = null, CharacterSize size = CharacterSize.Medium, ICollection<BodyPart> bodyParts = null)
        {
            Character = character;
            Strength = strength;
            Vitality = vitality;
            Size = size;
            Encumbrance = encumbrance ?? new Encumbrance();
            BodyParts = bodyParts ?? new List<BodyPart>();
        }

        public void AddBodyPart(BodyPart bodyPart)
        {
            if(!BodyParts.Contains(bodyPart))
                BodyParts.Add(bodyPart);
        }

        public void RemoveBodyPart(BodyPart bodyPart)
        {
            BodyParts.Remove(bodyPart);

            if (bodyPart.IsSpectral && bodyPart.IsVital)
                Character.Destroy();
        }

        public void SpectralizeBodyParts()
        {
            foreach (var bodyPart in BodyParts)
                bodyPart.Spectralize();
        }

        public void ItemizeBodyParts()
        {
            foreach (var bodyPart in BodyParts)
                bodyPart.Itemize();
        }
    }
}

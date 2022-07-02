using Assets.Scripts.Items;

namespace Assets.Scripts.Characters.BodyParts
{
    class Head : BodyPart
    {
        public Head(Anatomy anatomy, bool isVital = false, bool isMechanical = false, bool isSpectral = false, Life life = null, Energy energy = null, Soul soul = null, InventoryLimited inventory = null)
            : base(
                  isVital: isVital,
                  anatomy: anatomy,
                  isMechanical: isMechanical, 
                  isSpectral: isSpectral, 
                  life: life, 
                  energy: energy, 
                  soul: soul, 
                  inventory: inventory) { }
    }
}

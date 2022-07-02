using Assets.Scripts.Items;

namespace Assets.Scripts.Characters.BodyParts
{
    public class Body : BodyPart
    {
        public Body(Anatomy anatomy, bool isMechanical = false, bool isSpectral = false, Life life = null, Energy energy = null, Soul soul = null, InventoryLimited inventory = null) 
            : base(
                  isVital: true,
                  anatomy: anatomy,
                  isMechanical: isMechanical,
                  isSpectral: isSpectral,
                  life: life,
                  energy: energy,
                  soul: soul,
                  inventory: inventory
                  ) { }
    }
}

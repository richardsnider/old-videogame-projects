using Assets.Scripts.Items;

namespace Assets.Scripts.Characters.BodyParts
{
    /// <summary>
    /// Represents arms, tails, and tentacles.
    /// </summary>
    public class Arm : BodyPart, IHasGrip
    {
        public Arm(Anatomy anatomy, bool isVital = false, bool isMechanical = false, bool isSpectral = false, Life life = null, Energy energy = null, Soul soul = null, InventoryLimited inventory = null)
            : base(
                  isVital: isVital,
                  anatomy: anatomy,
                  isMechanical: isMechanical, 
                  isSpectral: isSpectral, 
                  life: life, 
                  energy: energy, 
                  soul: soul,
                  inventory:inventory) { }

        public void Wield(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void Pickup(IHasInventory source, Inventory destination, Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}

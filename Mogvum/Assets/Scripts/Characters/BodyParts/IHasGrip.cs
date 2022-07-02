using Assets.Scripts.Items;

namespace Assets.Scripts.Characters.BodyParts
{
    interface IHasGrip
    {
        void Wield(Item item);
        void Pickup(IHasInventory source, Inventory destination, Item item);
    }
}

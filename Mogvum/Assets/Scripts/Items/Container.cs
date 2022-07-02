using System;
using Assets.Scripts.Regions;

namespace Assets.Scripts.Items
{
    [Serializable]
    public class Container : Item, IHasInventory
    {
        public Inventory Inventory { get; private set; }
        public RegionCube Cube
        {
            get { return ContainingInventory.Holder.Cube; }
        }

        public Container(Inventory containingInventory, string name = null, int weight = 0, int size = 0,
            Condition condition = null, bool isEquipment = false, Inventory inventory = null)
            : base(
                containingInventory: containingInventory,
                name: name,
                weight: weight,
                size: size,
                condition: condition,
                isEquipment: isEquipment
                )
        {
            Inventory = inventory ?? new Inventory(this);
        }
    }
}

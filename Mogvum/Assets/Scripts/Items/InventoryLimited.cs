using System;
using System.Collections.Generic;

namespace Assets.Scripts.Items
{
    [Serializable]
    public class InventoryLimited : Inventory
    {
        public int CurrentCapacity { get; private set; }
        public int MaxCapacity { get; private set; }

        public InventoryLimited(IHasInventory holder, ICollection<Item> items = null, int gold = 0, int currentCapacity = 0, int maxCapacity = 1) : base(holder, items, gold)
        {
            CurrentCapacity = currentCapacity;
            MaxCapacity = (maxCapacity < 1) ? 1 : maxCapacity;
        }

        public new bool AddItem(Item item)
        {
            if (CurrentCapacity + item.Size > MaxCapacity) return false;

            CurrentCapacity += item.Size;
            return base.AddItem(item);
        }

        public new Item RemoveItem(Item item)
        {
            if (base.RemoveItem(item) == null) return null;

            CurrentCapacity -= item.Size;
            return item;
        }
    }
}

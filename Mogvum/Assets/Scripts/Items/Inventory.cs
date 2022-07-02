using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Items
{
    [Serializable]
    public class Inventory
    {
        public IHasInventory Holder { get; private set; }
        public ICollection<Item> Items { get; private set; }
        public int Gold { get; private set; }

        public Inventory(IHasInventory holder, ICollection<Item> items = null, int gold = 0)
        {
            Holder = holder;
            Items = items ?? new List<Item>();
            Gold = (gold < 0) ? 0 : gold;
        }

        public bool AddItem(Item item)
        {
            if (Items.Contains(item)) return false;

            Items.Add(item);
            return true;
        }

        public Item RemoveItem(Item item)
        {
            if (!Items.Contains((item))) return null;

            Items.Remove(item);
            return item;
        }

        public List<Item> GetItemsByName(string name)
        {
            return Items.Where(i => i.Name == name).ToList();
        }
    }
}

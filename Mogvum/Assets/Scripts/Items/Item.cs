using System;
using System.Collections.Generic;
using Assets.Scripts.Abilities;
using Assets.Scripts.Effects;

namespace Assets.Scripts.Items
{
    [Serializable]
    public class Item
    {
        protected Inventory ContainingInventory { get; set; } //Handle to containing ContainingInventory.
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public int Size { get; private set; }
        public Condition Condition { get; set; }
        public bool IsEquipment { get; private set; }
        public bool IsSpectral { get; private set; }
        public Resistance Resistance { get; private set; }
        public ICollection<Ability> Abilities { get; private set; }

        public Item(Inventory containingInventory, string name = null, int weight = 0, int size = 0, Condition condition = null, bool isEquipment = false, bool isSpectral = false, Resistance resistance = null)
        {
            ContainingInventory = containingInventory;
            Name = name;
            Weight = (weight < 0) ? 0 : weight;
            Size = (size < 0) ? 0 : size;
            Condition = condition ?? new Condition(this);
            IsEquipment = isEquipment;
            IsSpectral = isSpectral;
            Resistance = resistance;
        }

        /// <summary>
        /// Base item attack.
        /// </summary>
        public void Attack()
        {
            
        }
    }

    public class Apparrel : Item
    {
        /// <summary>
        /// Determines the percent amount of each damage type that is dealt to the item instead of the body part. If the item is destroyed, left over damage SHOULD be applied to the protected body part.
        /// </summary>
        public Resistance Absorption { get; set; }

        public Apparrel(Inventory containingInventory, string name = null, int weight = 0, int size = 0, Condition condition = null, bool isEquipment = false, bool isSpectral = false, Resistance resistance = null) : base(containingInventory, name, weight, size, condition, isEquipment, isSpectral, resistance)
        {
        }
    }

    public class Weapon : Item
    {
        /// <summary>
        /// Adjusts the amount that encumbrance affects attacks.
        /// </summary>
        public double EncumbranceModifier { get; set; }

        public Weapon(Inventory containingInventory, string name = null, int weight = 0, int size = 0, Condition condition = null, bool equippable = false, bool isSpectral = false, Resistance resistance = null) : base(containingInventory, name, weight, size, condition, equippable, isSpectral, resistance)
        {
        }
    }

    public class Consumable : Item
    {
        public Consumable(Inventory containingInventory, string name = null, int weight = 0, int size = 0, Condition condition = null, bool isEquipment = false, bool isSpectral = false, Resistance resistance = null) : base(containingInventory, name, weight, size, condition, isEquipment, isSpectral, resistance)
        {
        }
    }
}

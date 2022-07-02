using Assets.Scripts.Effects;
using Assets.Scripts.Items;
using Assets.Scripts.Regions;

namespace Assets.Scripts.Characters.BodyParts
{
    public class BodyPart : IHasInventory
    {
        protected Anatomy Anatomy { get; set; }

        public bool IsVital { get; private set; }
        public bool IsMechanical { get; private set; }
        public bool IsSpectral { get; private set; }

        public Life Life { get; private set; }
        public Energy Energy { get; private set; }
        public Soul Soul { get; private set; }
        public Resistance Resistance { get; private set; }

        public InventoryLimited Inventory { get; private set;  }

        public BodyPart(Anatomy anatomy, bool isVital = false, bool isMechanical = false, bool isSpectral = false, Life life = null, Energy energy = null, Soul soul = null, Resistance resistance = null, InventoryLimited inventory = null)
        {
            Anatomy = anatomy;

            IsVital = isVital;
            IsMechanical = isMechanical;
            IsSpectral = isSpectral;

            Life = life ?? new Life(this);
            Soul = soul ?? new Soul(this);
            Energy = energy ?? new Energy(this);
            Resistance = resistance ?? new Resistance();

            Inventory = inventory ?? new InventoryLimited(this);
        }

        public void Destroy()
        {
            if (IsVital) Anatomy.SpectralizeBodyParts();
            else Itemize();
        }

        public void Itemize()
        {
            var inventory = Cube.Inventory;
            inventory.AddItem(new Item(inventory, GetType() + " of " + Anatomy.Character.Titles.Default));
        }

        public void Spectralize()
        {
            IsSpectral = true;
        }

        public bool IsLimb
        {
            get
            {
                if (GetType() == typeof (Leg) || GetType() == typeof(Fin) 
                    || GetType() == typeof(Wing) || GetType() == typeof(Arm)) return true;

                return false;
            }
        }

        public RegionCube Cube
        {
            get { return Anatomy.Character.Cube; }
        }
    }
}

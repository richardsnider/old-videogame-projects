namespace Assets.Scripts.Effects
{
    public class Resistance
    {
        private decimal sharp;
        public decimal Sharp
        {
            get { return sharp; }
            set { sharp = value >= 1 ? 1 : value; }
        }

        private decimal blunt;
        public decimal Blunt
        {
            get { return blunt; }
            set { blunt = value >= 1 ? 1 : value; }
        }

        private decimal soul;
        public decimal Soul
        {
            get { return soul; }
            set { soul = value >= 1 ? 1 : value; }
        }

        private decimal chemical;
        public decimal Chemical
        {
            get { return chemical; }
            set { chemical = value >= 1 ? 1 : value; }
        }

        private decimal burn;
        public decimal Burn
        {
            get { return burn; }
            set { burn = value >= 1 ? 1 : value; }
        }

        private decimal frost;
        public decimal Frost
        {
            get { return frost; }
            set { frost = value >= 1 ? 1 : value; }
        }

        private decimal lightning;
        public decimal Lightning
        {
            get { return lightning; }
            set { lightning = value >= 1 ? 1 : value; }
        }

        public Resistance(decimal sharp = 0, decimal blunt = 0, decimal soul = 0, decimal chemical = 0, decimal burn = 0, decimal frost = 0, decimal lightning = 0)
        {
            Sharp = sharp;
            Blunt = blunt;
            Soul = soul;
            Chemical = chemical;
            Burn = burn;
            Frost = frost;
            Lightning = lightning;
        }
    }
}

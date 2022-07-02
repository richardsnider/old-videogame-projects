using System;

namespace Assets.Scripts
{
    public class Version
    {
        public int Edition { get; set; }
        public float Patch { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            return "Mogvum v" + Edition + "." + Patch;
        }
    }
}

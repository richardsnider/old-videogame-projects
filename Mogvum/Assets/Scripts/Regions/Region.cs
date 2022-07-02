using System;
using System.Collections.Generic;

namespace Assets.Scripts.Regions
{
    [Serializable]
    public class Region
    {
        public World World { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public string Name { get; private set; }
        public TerrainType Terrain { get; private set; }
        public int XSize { get; private set; }
        public int YSize { get; private set; }
        public int ZSize { get; private set; }
        public int Elevation { get; private set; }

        //Region needs a Weather class property

        public ICollection<RegionCube> Cubes { get; private set; }

        public Region(World world, int x, int y, string name = null, TerrainType terrain = TerrainType.Fog,
            int xSize = 1000, int ySize = 1000, int zSize = 1000, int elevation = 100,
            ICollection<RegionCube> cubes = null)
        {
            World = world;
            X = x;
            Y = y;

            Name = name ?? "DefaultRegionName";
            Terrain = terrain;
            XSize = xSize;
            YSize = ySize;
            ZSize = zSize;
            Elevation = elevation;
            Cubes = cubes ?? new List<RegionCube>();
        }

        public void Day()
        {
            //Have each character in the region take a turn.
        }
    }
}

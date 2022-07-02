using System;
using Assets.Scripts.Regions;

namespace Assets.Scripts.Items
{
    public interface IHasInventory
    {
        RegionCube Cube { get; }
    }
}

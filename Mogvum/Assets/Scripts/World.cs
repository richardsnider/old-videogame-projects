using System;
using System.Collections.Generic;
using Assets.Scripts.Characters;
using Assets.Scripts.Players;
using Assets.Scripts.Regions;

namespace Assets.Scripts
{
    [Serializable]
    public class World
    {
        public Game Game { get; private set; }
        public ICollection<Faction> Factions { get; private set; }
        public ICollection<Region> Regions { get; private set; }
        public uint Date { get; private set; }

        public World(Game game, ICollection<Faction> factions = null, ICollection<Region> regions = null, int startingFactions = 1, int startingRegions = 1, UInt32 date = 0)
        {
            Game = game;
            Factions = factions ?? new List<Faction>();
            Regions = regions ?? new List<Region>();
            Date = date;

            if(Factions.Count < 1)
                AddFactions(startingFactions);

            if(Regions.Count < 1)
                AddRegions(startingRegions);
        }

        public void Resume()
        {
            foreach(var region in Regions)
            {
                region.Day();
            }
        }

        public void Pause()
        {

        }

        public void AddFactions(int numFactions)
        {
            if (numFactions < 1) numFactions = 1;

            for(; numFactions > 0; numFactions--)
            {
                Factions.Add(new Faction(this));
            }
        }

        public void AddRegions(int numRegions)
        {
            if (numRegions < 1) numRegions = 1;

            for(; numRegions > 0; numRegions--)
            {
                //What is the best way to calculate coordinates?
                Regions.Add(new Region(this, 0, 0, "test", TerrainType.Fog));
            }
        }

        public void RemoveFaction(Faction faction)
        {
            if(Factions.Contains(faction))
                Factions.Remove(faction);
        }

        public void MoveCharacter(RegionCube src, RegionCube dst, Character character)
        {
            src.AddOccupant(dst.RemoveOccupant(character));
        }
    }
}

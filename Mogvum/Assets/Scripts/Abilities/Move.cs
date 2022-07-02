using Assets.Scripts.Characters;
using Assets.Scripts.Regions;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class MoveOne : Ability
    {
        public void Attempt(Character source, RegionCube target)
        {
            Debug.Log("Unable to move.");

        }

        public void Perform(Character source, RegionCube target)
        {
            target.AddOccupant(source);


            //character.Stats.Energy -= character.Skills.Kinesis.Move;
            //character.Stats.Energy -= character.Skills.Kinesis.GetLevel();

            //src.occupants.Remove(character);
            //dest.occupants.Add(character);
            //Debug.Log(character.FirstName);
        }
    }
}

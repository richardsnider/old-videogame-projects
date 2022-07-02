namespace Assets.Scripts.Abilities
{
    public abstract class Ability : IAbility
    {
        bool counter;




        /// <summary>
        /// Stop the ability from performing.
        /// </summary>
        public void Counter()
        {
            
        }


        public void Perform()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IAbility
    {
        void Perform();
    }

    interface IAbilityToggle : IAbility
    {
    }

    interface IItemAbility
    {
         
    }
}

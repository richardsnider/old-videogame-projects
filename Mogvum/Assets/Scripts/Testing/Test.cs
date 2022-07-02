using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Testing
{
    public static class Test
    {
        public static void GamePersistence()
        {
            Debug.Log("Beginning GamePersistence test.");
            string gameName = "Test Case Game Name";
            Game game = new Game(name: gameName);

            Persistence.Save(game);

            var loadedGame = Persistence.Load(game.Id);

            if (loadedGame.Name == gameName)
                Debug.Log("GamePersistence test passed.");
            else Debug.LogError("GamePersistence test failed. Loaded game name is " + loadedGame.Name + ", but should be " + gameName);
        }

        public static void GenerateNames()
        {
            var names = NameGenerator.CreateNames(numOfNames: 10);
            string debug = "";

            foreach(var name in names)
            {
                debug += name + "\n";
            }

            Debug.Log("Generated names: " + debug);
        }
    }
}

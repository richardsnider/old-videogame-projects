using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utilities
{
    public static class Persistence
    {
        public static void Save(Game game)
        {
            if (game != null)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = File.Create(Application.persistentDataPath + "/" + game.Id + ".mog");

                game.UpdateSaveDate();
                binaryFormatter.Serialize(fileStream, game);

                fileStream.Close();
            }
        }

        public static Game Load(Guid gameId)
        {
            string filePath = Application.persistentDataPath + "/" + gameId + ".mog";

            if (!File.Exists(filePath)) return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(filePath, FileMode.Open);
            var game = (Game)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            return game;
        }

        public static List<Game> LoadAll()
        {
            List<Game> savedGames = new List<Game>();
            string path = Application.persistentDataPath + "/";
            string[] filePaths = Directory.GetFiles(path);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            foreach(var filePath in filePaths)
            {
                if(filePath.EndsWith(".mog") && File.Exists(filePath))
                {
                    FileStream fileStream = File.Open(filePath, FileMode.Open);
                    savedGames.Add((Game)binaryFormatter.Deserialize(fileStream));
                    fileStream.Close();
                }
            }

            return savedGames;
        }

        public static void Delete(Guid gameId)
        {
            string filePath = Application.persistentDataPath + "/" + gameId + ".mog";

            if(File.Exists(filePath)) File.Delete(filePath);
        }
    }
}

using System;
using System.IO;
using System.Xml.Serialization;
using Assets.Scripts.Utilities;

namespace Assets.Scripts
{
    [Serializable]
    public class Game
    {
        [XmlAttribute("Id")]
        public Guid Id { get; private set; }
        [XmlAttribute("Name")]
        public string Name { get; private set; }
        public DateTime SaveDate { get; private set; }
        public Version Version { get; set; }
        public World World { get; private set; }

        public Game(Guid id = new Guid(), DateTime? saveDate = null, 
            Version version = null,
            string name = null, World world = null)
        {
            Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            SaveDate = saveDate ?? DateTime.Now;
            Version = version ?? new Version();

            Name = name;
            World = world ?? new World(this);
            
            Log.Initialize(this);
        }

        public void Play()
        {
            World.Resume();
        }

        public void UpdateSaveDate()
        {
            SaveDate = DateTime.Now;
        }

    }
}

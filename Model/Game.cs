using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Royale_Platformer.Model
{
    class Game : Serializer
    {
        public CharacterPlayer PlayerCharacter { get; private set; }
        public List<Character> Characters { get; private set; }

        public List<Pickup> Pickups { get; set; }
        public List<Bullet> Bullets { get; set; }

        public Game()
        {

        }

        public void Update()
        {

        }

        public void CreatePlayer(CharacterPlayer character)
        {

        }

        public void AddCharacter(Character character)
        {

        }

        public string Serialize() {
          return "";
        }

        public Serializer Deserialize(string serialized) {
          return new Game();
        }

        public Game Load()
        {
            return new Game();
        }
        
        public void Save()
        {
            const string PATH = "./.data/state.txt";

            // string serialized = Serialize();
            string serialized = "PlayerCharacter;Characters;Pickups;Bullets";

            File.WriteAllText(PATH, serialized);
        }
    }
}

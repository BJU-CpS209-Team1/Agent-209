using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Royale_Platformer.Model
{
    class Game : ISerializer
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

        public string Serialize()
        {
            // dummy data to test
            return "PlayerCharacter=CharacterPlayer.Scout;Characters=Character1,Character2,Character3;Pickups=Pickup1,Pickup2;Bullets=Bullet1,Bullet2";
        }

        public ISerializer Deserialize(string serialized)
        {
            return new Game();
        }

        public Game Load(string fileName)
        {
            string path = $"./.data/{fileName}";

            if (File.Exists(path))
            {
                string data = File.ReadLines(path).First();
                return (Game) Deserialize(data);
            }
            else
            {
                throw new Exception("The call could not be completed as dialed. Please check check the number, and try your call again.");
            }
        }

        public void Save(string fileName)
        {
            // create .data folder and make it private
            const string PATH = "./.data/";
            if (!Directory.Exists(PATH))
            {
                DirectoryInfo pathInfo = Directory.CreateDirectory(PATH);
                pathInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            // Write data to file
            string serialized = Serialize();
            File.WriteAllText(PATH + fileName, serialized);
        }
    }
}

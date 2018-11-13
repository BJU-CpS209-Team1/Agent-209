using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Royale_Platformer.Model.SerializeTests
{
    [TestFixture]
    class TestGame
    {
        [Test]
        public void Game_Serialize_SerializesObject()
        {
            GameApp game = new GameApp(null);

            // Create things to test
            game.AddCharacter(new CharacterEnemy(CharacterClass.Tank, 0));
            game.AddCharacter(new CharacterEnemy(CharacterClass.Support, 0));
            game.AddPlayer(new CharacterPlayer(CharacterClass.Support, 0));

            string serialized = game.Serialize();
            Assert.IsTrue(serialized == "PlayerCharacter;Characters;Pickups;Bullets");
        }

        [Test]
        public void Game_Deserialize_CreatesObject()
        {
            string serialized = "PlayerCharacter;Characters;Pickups;Bullets";
            GameApp game = new GameApp(null);
            Assert.IsTrue(serialized == game.Serialize());
        }

        [Test]
        public void Game_Save_CreatesFileWithGameData()
        {
            // retrieve current serialized data from created file to test
            string path = "./.data/test.txt";
            string originalData = File.ReadLines(path).First();

            // Load the new game
            GameApp game = new GameApp(null);
            game.Load("test.txt");

            // Serialize new game to test
            game.Save("test.txt");
            string newData = File.ReadLines(path).First();

            Assert.IsTrue(newData == originalData);
        }

        [Test]
        public void Game_Load_CreatesNewGameFromFileWithData()
        {
            const string TEST_DATA = "PlayerCharacter=CharacterPlayer.Scout;Characters=Character1,Character2,Character3;Pickups=Pickup1,Pickup2;Bullets=Bullet1,Bullet2";
            GameApp game = new GameApp(null);
            // Add and update properties to test on game here

            game.Save("test.txt");

            // retrieve data from created file to test
            string path = "./.data/test.txt";
            string data = File.ReadLines(path).First();

            // TEST_DATA will be replaced with actual values later
            Assert.IsTrue(data == TEST_DATA);
        }
    }
}

using NUnit.Framework;

namespace Royale_Platformer.Model.SerializeTests
{
    [TestFixture]
    class TestGame
    {
        [Test]
        public void Game_Serialize_SerializesObject()
        {
            Game game = new Game();

            // Create things to test
            game.AddCharacter(new CharacterEnemy(CharacterClass.Tank, 0));
            game.AddCharacter(new CharacterEnemy(CharacterClass.Support, 0));
            game.CreatePlayer(new CharacterPlayer(CharacterClass.Support, 0));

            string serialized = game.Serialize();
            Assert.IsTrue(serialized == "PlayerCharacter;Characters;Pickups;Bullets");
        }

        public void Game_Deserialize_CreatesObject()
        {
            string serialized = "PlayerCharacter;Characters;Pickups;Bullets";
            Game game = new Game();
            Assert.IsTrue(serialized == game.Serialize());
        }
    }
}

using NUnit.Framework;

namespace Royale_Platformer.Model.SerializeTests
{
    [TestFixture]
    class TestCharacter
    {
        [Test]
        public void Game_Serialize_SerializesObject()
        {
            CharacterEnemy enemy = new CharacterEnemy(CharacterClass.Tank, 10);

            string serialized = enemy.Serialize();
            Assert.IsTrue(serialized == "Class=CharacterClass.Tank;HeldWeapon;Armor;MaxHealth=10;Health;Score");
        }

        public void Game_Deserialize_CreatesObject()
        {
            string serialized = "Class=CharacterClass.Tank;HeldWeapon;Armor;MaxHealth=10;Health;Score";
            CharacterEnemy enemy = new CharacterEnemy(CharacterClass.Tank, 10);
            Assert.IsTrue(serialized == enemy.Serialize());
        }
    }
}
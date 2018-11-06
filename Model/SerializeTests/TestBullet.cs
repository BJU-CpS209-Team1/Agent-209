using NUnit.Framework;

namespace Royale_Platformer.Model.SerializeTests
{
    [TestFixture]
    class TestBullet
    {
        [Test]
        public void Game_Serialize_SerializesObject()
        {
            Bullet bullet = new Bullet(10);

            string serialized = bullet.Serialize();
            Assert.IsTrue(serialized == "Damage=10");
        }

        public void Game_Deserialize_CreatesObject()
        {
            string serialized = "Damage=10";
            Bullet bullet = new Bullet(10);
            Assert.IsTrue(serialized == bullet.Serialize());
        }
    }
}
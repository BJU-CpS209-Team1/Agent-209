using NUnit.Framework;

namespace Royale_Platformer.Model.SerializeTests
{
    [TestFixture]
    class TestWeapon
    {
        [Test]
        public void Weapon_Serialize_SerializesObject()
        {
            WeaponAR ar = new WeaponAR();
            string serialized = ar.Serialize();

            Assert.IsTrue(serialized == "Upgradeable;MaxCooldown;CurrentCooldown");
        }

        public void Weapon_Deserialize_CreatesObject()
        {
            string serialized = "Upgradeable;MaxCooldown;CurrentCooldown";
            WeaponAR ar = new WeaponAR();
            Assert.IsTrue(serialized == ar.Serialize());
        }
    }
}

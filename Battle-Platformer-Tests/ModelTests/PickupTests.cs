using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.Tests
{
    [TestFixture]
    class PickupTests
    {
        [Test]
        public void Armor_Pickup()
        {
            Character character = new CharacterPlayer(CharacterClass.Gunner, 10);
            Assert.IsTrue(character.Armor == false);

            Pickup pickup = new PickupArmor();
            pickup.PickUp(character);

            Assert.IsTrue(character.Armor == true);
        }

        [Test]
        public void WeaponUpgrade_Pickup()
        {
            Character character = new CharacterPlayer(CharacterClass.Gunner, 10);
            Assert.IsTrue(character.HeldWeapon is WeaponKnife);

            Pickup pickup = new PickupWeaponUpgrade();
            pickup.PickUp(character);

            Assert.IsTrue(character.HeldWeapon is WeaponAR);
        }
    }
}

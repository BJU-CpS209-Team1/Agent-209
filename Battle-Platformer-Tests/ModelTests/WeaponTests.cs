using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;

namespace Royale_Platformer.Model.Tests
{
    [TestFixture]
    class WeaponTests
    {
        [Test]
        public void Weapon_Fire_CreatesBullets()
        {
            Weapon w = new WeaponAdvancedAR();
            Assert.IsTrue(w.Fire(Vector2.One).Count > 0);

            w = new WeaponAdvancedShotgun();
            Assert.IsTrue(w.Fire(Vector2.One).Count > 0);

            w = new WeaponAR();
            Assert.IsTrue(w.Fire(Vector2.One).Count > 0);

            w = new WeaponKnife();
            Assert.IsTrue(w.Fire(Vector2.One).Count > 0);

            w = new WeaponPistol();
            Assert.IsTrue(w.Fire(Vector2.One).Count > 0);

            w = new WeaponPistolShield();
            Assert.IsTrue(w.Fire(Vector2.One).Count > 0);

            w = new WeaponShotgun();
            Assert.IsTrue(w.Fire(Vector2.One).Count > 0);
        }

        [Test]
        public void Weapon_UpgradeWeapon_Gunner()
        {
            Weapon w = new WeaponKnife();

            w = w.Upgrade(CharacterClass.Gunner);
            Assert.IsTrue(w is WeaponAR);

            w = w.Upgrade(CharacterClass.Gunner);
            Assert.IsTrue(w is WeaponAdvancedAR);

            w = w.Upgrade(CharacterClass.Gunner);
            Assert.IsTrue(w is WeaponAdvancedAR);
        }

        [Test]
        public void Weapon_UpgradeWeapon_Support()
        {
            Weapon w = new WeaponKnife();

            w = w.Upgrade(CharacterClass.Support);
            Assert.IsTrue(w is WeaponShotgun);

            w = w.Upgrade(CharacterClass.Support);
            Assert.IsTrue(w is WeaponAdvancedShotgun);

            w = w.Upgrade(CharacterClass.Support);
            Assert.IsTrue(w is WeaponAdvancedShotgun);
        }

        [Test]
        public void Weapon_UpgradeWeapon_Tank()
        {
            Weapon w = new WeaponKnife();

            w = w.Upgrade(CharacterClass.Tank);
            Assert.IsTrue(w is WeaponPistol);

            w = w.Upgrade(CharacterClass.Tank);
            Assert.IsTrue(w is WeaponPistolShield);

            w = w.Upgrade(CharacterClass.Tank);
            Assert.IsTrue(w is WeaponPistolShield);
        }
    }
}

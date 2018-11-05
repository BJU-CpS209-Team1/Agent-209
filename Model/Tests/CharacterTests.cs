using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.Tests
{
    [TestFixture]
    class CharacterTests
    {
        [Test]
        public void Player_Constructor_ValidData()
        {
            Character character = new CharacterPlayer(CharacterClass.Gunner, 10);
            Assert.IsTrue(character.Class == CharacterClass.Gunner);
            Assert.IsTrue(character.HeldWeapon is WeaponKnife);
            Assert.IsTrue(character.Armor == false);
            Assert.IsTrue(character.MaxHealth == 10);
            Assert.IsTrue(character.Health == 10);
            Assert.IsTrue(character.Score == 0);
        }

        [Test]
        public void Player_Constructor_InvalidData()
        {
            try
            {
                Character character = new CharacterPlayer(CharacterClass.Gunner, -10);
                Assert.Fail();
            } catch { }
        }

        [Test]
        public void Player_Hit_LessHealth()
        {
            Character character = new CharacterPlayer(CharacterClass.Gunner, 10);
            Bullet b = new Bullet(3);
            character.Hit(b);

            Assert.IsTrue(character.Health == 7);
        }

        [Test]
        public void Player_Hit_DestroyArmor()
        {
            Character character = new CharacterPlayer(CharacterClass.Gunner, 10);
            character.Armor = true;
            Assert.IsTrue(character.Armor == true);

            Bullet b = new Bullet(1337);
            character.Hit(b);

            Assert.IsTrue(character.Health == 10);
            Assert.IsTrue(character.Armor == false);
        }

        [Test]
        public void Enemy_Constructor_ValidData()
        {
            Character character = new CharacterEnemy(CharacterClass.Gunner, 10);
            Assert.IsTrue(character.Class == CharacterClass.Gunner);
            Assert.IsTrue(character.HeldWeapon is WeaponKnife);
            Assert.IsTrue(character.Armor == false);
            Assert.IsTrue(character.MaxHealth == 10);
            Assert.IsTrue(character.Health == 10);
            Assert.IsTrue(character.Score == 0);
        }

        [Test]
        public void Enemy_Constructor_InvalidData()
        {
            try
            {
                Character character = new CharacterEnemy(CharacterClass.Gunner, -10);
                Assert.Fail();
            } catch { }
        }

        [Test]
        public void Enemy_Hit_LessHealth()
        {
            Character character = new CharacterEnemy(CharacterClass.Gunner, 10);
            Bullet b = new Bullet(3);
            character.Hit(b);

            Assert.IsTrue(character.Health == 7);
        }

        [Test]
        public void Enemy_Hit_DestroyArmor()
        {
            Character character = new CharacterEnemy(CharacterClass.Gunner, 10);
            character.Armor = true;
            Assert.IsTrue(character.Armor == true);

            Bullet b = new Bullet(1337);
            character.Hit(b);

            Assert.IsTrue(character.Health == 10);
            Assert.IsTrue(character.Armor == false);
        }
    }
}

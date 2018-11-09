using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.Tests
{
    [TestFixture]
    class BulletTests
    {
        [Test]
        public void Constructor_ValidDamage()
        {
            Bullet b = new Bullet(42);
            Assert.IsTrue(b.Damage == 42);
        }

        [Test]
        public void Constructor_InvalidDamage()
        {
            try
            {
                Bullet b = new Bullet(-1);
                Assert.Fail();
            } catch { }
        }
    }
}

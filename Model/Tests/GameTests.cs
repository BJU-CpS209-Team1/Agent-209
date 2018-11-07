using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.Tests
{
    [TestFixture]
    class GameTests
    {
        [Test]
        public void CreatePlayer_Valid()
        {
            Game game = new Game();
            game.CreatePlayer(new CharacterPlayer(CharacterClass.Gunner, 10));

            Assert.IsTrue(game.PlayerCharacter != null);
            Assert.IsTrue(game.Characters.Count == 1);
        }

        [Test]
        public void AddCharacter_Valid()
        {
            Game game = new Game();
            game.AddCharacter(new CharacterEnemy(CharacterClass.Support, 20));

            Assert.IsTrue(game.PlayerCharacter == null);
            Assert.IsTrue(game.Characters.Count == 1);
        }
    }
}

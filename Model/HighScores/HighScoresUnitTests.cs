using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.HighScores
{
    [TestFixture]
    class HighScoresUnitTests
    {
        [Test]
        public void AddHighScore_PlayerAndScore_AddsToLists()
        {
            List<HighScore> myScores = new List<HighScore>();
            myScores.Add(new HighScore("David", 100));
            myScores.Add(new HighScore("Stephen", 200));
            myScores.Add(new HighScore("Matthew", 300));

            HighScoresManager h = new HighScoresManager();
            h.AddHighScore("David", 100);
            h.AddHighScore("Matthew", 200);
            h.AddHighScore("Stephen", 300);
            List<HighScore> scores = h.GetHighScores();
            for (int i = 0; i < myScores.Count; i++)
            {
                Assert.IsTrue(myScores[i].Equals(scores[i]));
            }
        }
    }
}

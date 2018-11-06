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
            List<HighScore> myHighScores = new List<HighScore>();
            myHighScores.Add(new HighScore("David", 100));
            myHighScores.Add(new HighScore("Matthew", 200));
            myHighScores.Add(new HighScore("Stephen", 300));
            List<string> myNames = new List<string>();
            List<int> myScores = new List<int>();
            foreach (HighScore item in myHighScores)
            {
                myNames.Add(item.GetName());
                myScores.Add(item.GetScore());
            }

            HighScoresManager h = new HighScoresManager();
            h.AddHighScore("David", 100);
            h.AddHighScore("Matthew", 200);
            h.AddHighScore("Stephen", 300);
            List<HighScore> highScores = h.GetHighScores();
            List<string> names = new List<string>();
            List<int> scores = new List<int>();
            foreach (HighScore item in highScores)
            {
                names.Add(item.GetName());
                scores.Add(item.GetScore());
            }

            for (int i = 0; i < myScores.Count; i++)
            {
                Assert.IsTrue(myNames[i].Equals(names[i]) && myScores[i].Equals(scores[i]));
            }
        }
    }
}

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
        public void AddScore_PlayerAndScore_AddsToLists()
        {
            List<string> myNames = new List<string>();
            List<int> myScores = new List<int>();
            myNames.Add("David");
            myNames.Add("Matthew");
            myNames.Add("Stephen");
            myScores.Add(100);
            myScores.Add(200);
            myScores.Add(300);

            HighScoresManager h = new HighScoresManager();
            h.AddScore("David", 100);
            h.AddScore("Matthew", 200);
            h.AddScore("Stephen", 300);
            List<string> names = h.GetNames();
            List<int> scores = h.GetScores();
            for (int i = 0; i < myNames.Count; i++)
            {
                Assert.IsTrue(myNames[i] == names[i]);
            }

            for (int i = 0; i < myScores.Count; i++)
            {
                Assert.IsTrue(myScores[i] == scores[i]);
            }
        }
    }
}

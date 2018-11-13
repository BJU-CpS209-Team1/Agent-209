using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Royale_Platformer.Model.HighScores
{
    [TestFixture]
    class HighScoresUnitTests
    {
        [Test]
        public void AddHighScore_PlayerAndScore_AddsToLists()
        {
            HighScoresManager h = new HighScoresManager();
            h.AddHighScore("David", 2000);
            h.AddHighScore("Matthew", 1500);
            h.AddHighScore("Stephen", 3000);
            h.AddHighScore("Isaac", 1000);
            h.AddHighScore("Elias", 2500);

            Assert.IsTrue(h.GetHighScores()[0].GetScore() == 3000 && h.GetHighScores()[0].GetName() == "Stephen");
            Assert.IsTrue(h.GetHighScores()[1].GetScore() == 2500 && h.GetHighScores()[1].GetName() == "Elias");
            Assert.IsTrue(h.GetHighScores()[2].GetScore() == 2000 && h.GetHighScores()[2].GetName() == "David");
            Assert.IsTrue(h.GetHighScores()[3].GetScore() == 1500 && h.GetHighScores()[3].GetName() == "Matthew");
            Assert.IsTrue(h.GetHighScores()[4].GetScore() == 1000 && h.GetHighScores()[4].GetName() == "Isaac");
        }

        [Test]
        public void WriteScores_CreateFile_FileIsCreated()
        {
            HighScoresManager h = new HighScoresManager();
            h.WriteScores();
            Assert.IsTrue(File.Exists("HighScores.txt"));
        }

        [Test]
        public void ReadScoresToUpdate_ScoresWritten_ScoresRead()
        {
            HighScoresManager h = new HighScoresManager();

            h.AddHighScore("David", 2000);
            h.AddHighScore("Matthew", 1500);
            h.AddHighScore("Stephen", 3000);
            h.AddHighScore("Isaac", 1000);
            h.AddHighScore("Elias", 2500);

            h.WriteScores();
            h.ClearHighScores();
            h.ReadScoresToUpdate();
            Assert.IsTrue(h.GetHighScores()[0].GetScore() == 3000 && h.GetHighScores()[0].GetName() == "Stephen");
            Assert.IsTrue(h.GetHighScores()[1].GetScore() == 2500 && h.GetHighScores()[1].GetName() == "Elias");
            Assert.IsTrue(h.GetHighScores()[2].GetScore() == 2000 && h.GetHighScores()[2].GetName() == "David");
            Assert.IsTrue(h.GetHighScores()[3].GetScore() == 1500 && h.GetHighScores()[3].GetName() == "Matthew");
            Assert.IsTrue(h.GetHighScores()[4].GetScore() == 1000 && h.GetHighScores()[4].GetName() == "Isaac");
        }

        [Test]
        public void ReadScoresToUpdate_ScoresNotWritten_ThrowsException()
        {
            try
            {
                HighScoresManager h = new HighScoresManager();

                h.AddHighScore("David", 2000);
                h.AddHighScore("Matthew", 1500);
                h.AddHighScore("Stephen", 3000);
                h.AddHighScore("Isaac", 1000);
                h.AddHighScore("Elias", 2500);

                h.ReadScoresToUpdate();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message == "scores.txt file does not exist.");
            }
        }

        [Test]
        public void CheckScore_HighScore_True()
        {
            HighScoresManager h = new HighScoresManager();
            bool check = h.CheckScore(3000);
            Assert.IsTrue(check == true);
        }

        [Test]
        public void CheckScore_LowScore_False()
        {
            HighScoresManager h = new HighScoresManager();
            bool check = h.CheckScore(2000);
            Assert.IsTrue(check == false);
        }

        [Test]
        public void ClearHighScores_ClearedScores_Passes()
        {
            HighScoresManager h = new HighScoresManager();

            h.AddHighScore("David", 2000);
            h.AddHighScore("Matthew", 1500);
            h.AddHighScore("Stephen", 3000);
            h.AddHighScore("Isaac", 1000);
            h.AddHighScore("Elias", 2500);

            h.ClearHighScores();

            Assert.IsTrue(h.GetHighScores().Count == 0);
        }
    }
}

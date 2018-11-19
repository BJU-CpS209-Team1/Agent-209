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
            HighScoresManager.AddHighScore("David", 2000);
            HighScoresManager.AddHighScore("Matthew", 1500);
            HighScoresManager.AddHighScore("Stephen", 3000);
            HighScoresManager.AddHighScore("Isaac", 1000);
            HighScoresManager.AddHighScore("Elias", 2500);

            Assert.IsTrue(HighScoresManager.GetHighScores()[0].GetScore() == 3000 && HighScoresManager.GetHighScores()[0].GetName() == "Stephen");
            Assert.IsTrue(HighScoresManager.GetHighScores()[1].GetScore() == 2500 && HighScoresManager.GetHighScores()[1].GetName() == "Elias");
            Assert.IsTrue(HighScoresManager.GetHighScores()[2].GetScore() == 2000 && HighScoresManager.GetHighScores()[2].GetName() == "David");
            Assert.IsTrue(HighScoresManager.GetHighScores()[3].GetScore() == 1500 && HighScoresManager.GetHighScores()[3].GetName() == "Matthew");
            Assert.IsTrue(HighScoresManager.GetHighScores()[4].GetScore() == 1000 && HighScoresManager.GetHighScores()[4].GetName() == "Isaac");
        }

        [Test]
        public void WriteScores_CreateFile_FileIsCreated()
        {
            HighScoresManager.WriteScores();
            string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "scores.txt");
            Assert.IsTrue(File.Exists(PATH));
        }

        [Test]
        public void ReadScores_ScoresWritten_ScoresRead()
        {
            HighScoresManager.AddHighScore("David", 2000);
            HighScoresManager.AddHighScore("Matthew", 1500);
            HighScoresManager.AddHighScore("Stephen", 3000);
            HighScoresManager.AddHighScore("Isaac", 1000);
            HighScoresManager.AddHighScore("Elias", 2500);

            HighScoresManager.WriteScores();
            List<HighScore> testList = HighScoresManager.ReadScores();
            testList.Add(new HighScore("Stephen", 3000));
            testList.Add(new HighScore("Elias", 2500));
            testList.Add(new HighScore("David", 2000));
            testList.Add(new HighScore("Matthew", 1500));
            testList.Add(new HighScore("Isaac", 1000));
            for (int i = 0; i < HighScoresManager.GetHighScores().Count; i++)
            {
                Assert.IsTrue(HighScoresManager.GetHighScores()[i].GetName() == testList[i].GetName() &&
                              HighScoresManager.GetHighScores()[i].GetScore() == testList[i].GetScore());
            }
        }

        [Test]
        public void ReadScores_ScoresNotWritten_ThrowsException()
        {
            try
            {
                HighScoresManager HighScoresManager = new HighScoresManager();

                HighScoresManager.AddHighScore("David", 2000);
                HighScoresManager.AddHighScore("Matthew", 1500);
                HighScoresManager.AddHighScore("Stephen", 3000);
                HighScoresManager.AddHighScore("Isaac", 1000);
                HighScoresManager.AddHighScore("Elias", 2500);

                List<HighScore> testList = HighScoresManager.ReadScores();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message == "scores.txt file does not exist.");
            }
        }

        [Test]
        public void CheckScore_HighScore_True()
        {
            bool check = HighScoresManager.CheckScore(3000);
            Assert.IsTrue(check == true);
        }

        [Test]
        public void CheckScore_LowScore_False()
        {
            bool check = HighScoresManager.CheckScore(2000);
            Assert.IsTrue(check == false);
        }

        [Test]
        public void ClearHighScores_ClearedScores_Passes()
        {
            HighScoresManager HighScoresManager = new HighScoresManager();

            HighScoresManager.AddHighScore("David", 2000);
            HighScoresManager.AddHighScore("Matthew", 1500);
            HighScoresManager.AddHighScore("Stephen", 3000);
            HighScoresManager.AddHighScore("Isaac", 1000);
            HighScoresManager.AddHighScore("Elias", 2500);

            HighScoresManager.ClearHighScores();

            Assert.IsTrue(HighScoresManager.GetHighScores().Count == 0);
        }
    }
}

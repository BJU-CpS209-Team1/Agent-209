using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Royale_Platformer.Model.HighScores
{
    public class HighScoresManager
    {
        private static List<HighScore> highScores = new List<HighScore>();
        public HighScoresManager()
        {
        }

        // Checks to see if score is a high score <score>
        // Returns true if score is a highscore (2500 or higher) and false if not a highscore
        public static bool CheckScore(int score)
        {
            if (score >= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Adds a player's name <name> and score <score> to the highScores list from greatest to least 
        public static void AddHighScore(string playerName, int playerScore)
        {
            highScores.Add(new HighScore(playerName, playerScore));

            // OrderBy function found at "https://stackoverflow.com/questions/16620135/sort-a-list-of-objects-by-the-value-of-a-property/16620159"
            highScores = highScores.OrderByDescending(x => x.GetScore()).ToList();

            if (highScores.Count > 10)
            {
                highScores.RemoveRange(10, highScores.Count - 10);
            }
        }

        // Writes the highScores List to a file
        public static void WriteScores()
        {
            string PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string infoList = "";
            foreach (HighScore score in highScores)
            {
                infoList += $"{score.GetName()},{score.GetScore()}\r\n";
            }
            File.WriteAllText(Path.Combine(PATH, "scores.txt"), infoList);
        }

        // Reads names and scores from a file and returns a list
        public static List<HighScore> ReadScores()
        {
            List<HighScore> scores = new List<HighScore>();

            string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "scores.txt");

            if (File.Exists(PATH))
            {
                foreach (var score in File.ReadLines(PATH))
                {
                    string[] items = score.Split(',');
                    scores.Add(new HighScore(items[0], Convert.ToInt32(items[1])));
                }
            }
            return scores;
        }

        // Returns names of players held in the list instance variable
        public static List<HighScore> GetHighScores()
        {
            return highScores;
        }

        // Provides the ability to clear highScores list for testing purposes
        public static void ClearHighScores()
        {
            highScores.Clear();
        }
    }
}



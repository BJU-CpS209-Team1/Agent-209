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
        private List<HighScore> highScores;
        public HighScoresManager()
        {
            highScores = new List<HighScore>();
            //AddHighScore("David", 2000);
            //AddHighScore("Matthew", 1500);
            //AddHighScore("Stephen", 3000);
            //AddHighScore("Isaac", 1000);
            //AddHighScore("Elias", 2500);
            //SortHighScores();
            //WriteScores();
        }

        // Checks to see if score is a high score <score>
        // Returns true if score is a highscore (2500 or higher) and false if not a highscore
        public bool CheckScore(int score)
        {
            if (score >= 2500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Adds a player's name <name> and score <score> to the highScores list from greatest to least 
        public void AddHighScore(string playerName, int playerScore)
        {
            highScores.Add(new HighScore(playerName, playerScore));

            // OrderBy function found at "https://stackoverflow.com/questions/16620135/sort-a-list-of-objects-by-the-value-of-a-property/16620159"
            highScores = highScores.OrderByDescending(x => x.GetScore()).ToList();
        }

        // Writes the highScores List to a file
        public void WriteScores()
        {
            //using (StreamWriter writer = new StreamWriter(File.Create("HighScores.txt")))
            //{
            //    foreach (HighScore score in highScores)
            //    {
            //        writer.WriteLine(score.GetName() + "," + score.GetScore());
            //    }
            //}

            string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "scores.txt");

            foreach (HighScore score in highScores)
            {
                File.WriteAllText(PATH, score.GetName() + "," + score.GetScore());
            }
        }

        // Reads names and scores from a file and puts them in the highScore list
        public void ReadScoresToUpdate()
        {
            if (File.Exists("HighScores.txt"))
            {
                using (StreamReader reader = new StreamReader(File.Open("HighScores.txt", FileMode.Open)))
                {
                    while (!reader.EndOfStream)
                    {
                        string score = reader.ReadLine();
                        string[] items = score.Split(',');
                        highScores.Add(new HighScore(items[0], Convert.ToInt32(items[1])));
                    }
                }
            }
            else
            {
                throw new Exception("HighScores.txt file does not exist.");
            }
        }

        // Reads names and scores from a file and returns a list
        public List<HighScore> ReadScoresToList()
        {
            int count = 0;
            List<HighScore> scores = new List<HighScore>();
            if (File.Exists("HighScores.txt"))
            {
                using (StreamReader reader = new StreamReader(File.Open("HighScores.txt", FileMode.Open)))
                {
                    while (!reader.EndOfStream)
                    {
                        string score = reader.ReadLine();
                        string[] items = score.Split(',');
                        scores[count] = new HighScore(items[0], Convert.ToInt32(items[1]));
                        count++;
                    }
                }
                return scores;
            }
            else
            {
                return scores;
            }
        }

        // Returns names of players held in the list instance variable
        public List<HighScore> GetHighScores()
        {
            return highScores;
        }

        // Provides the ability to clear highScores list for testing purposes
        public void ClearHighScores()
        {
            highScores.Clear();
        }
    }
}



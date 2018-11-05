using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Royale_Platformer.Model.HighScores
{
    class HighScoresManager
    {
        private List<HighScore> highScores;
        public HighScoresManager()
        {
            highScores = new List<HighScore>();
        }

        // Adds a player's name <name> and score <score> to the dictionary
        public void AddHighScore(string playerName, int playerScore)
        {
            highScores.Add(new HighScore(playerName, playerScore));
        }
        
        // Writes the highScores Dictionary to a file
        public void WriteScores()
        {

        }

        // Reads names and scores from a file and assigns them to the highScores Dictionary
        public void ReadScores()
        {

        }
        
        // Returns names of players held in the list instance variable
        public List<HighScore> GetHighScores()
        {
            return highScores;
        }
    }
}

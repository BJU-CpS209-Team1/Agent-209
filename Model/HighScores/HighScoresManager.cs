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
        private List<string> playerNames;
        private List<int> playerScores;
        public HighScoresManager()
        {
            playerNames = new List<string>();
            playerScores = new List<int>();
        }

        // Adds a player's name <name> and score <score> to the dictionary
        public void AddScore(string playerName, int playerScore)
        {
            playerNames.Add(playerName);
            playerScores.Add(playerScore);
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
        public List<string> GetNames()
        {
            return playerNames;
        }
        
        // Returns scores of players held in the list instance variable
        public List<int> GetScores()
        {
            return playerScores;
        }
    }
}

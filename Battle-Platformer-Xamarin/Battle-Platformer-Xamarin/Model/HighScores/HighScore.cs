//-----------------------------------------------------------
// HighScore.cs
// David
// HighScore
//----------------------------------------------------------- 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.HighScores
{
    // HighScore
    // Creates an object for storing a player's name and score
    public class HighScore
    {

        // name of player that acheived a highscore
        private string name;

        // score of player that acheived a highscore
        private int score;

        public HighScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        // Returns name of player
        public string GetName()
        {
            return name;
        }

        // Sets name of player <n>
        public void SetName(string n)
        {
            name = n;
        }

        // Returns score of player
        public int GetScore()
        {
            return score;
        }

        // Sets name of player <s>
        public void SetScore(int s)
        {
            score = s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.HighScores
{
    public class HighScore
    {
        private string name;
        private int score;
        public HighScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        // Returns name of player
        public string GetName()
        {
            return this.name;
        }

        // Sets name of player <n>
        public void SetName(string n)
        {
            this.name = n;
        }

        // Returns score of player
        public int GetScore()
        {
            return this.score;
        }

        // Sets name of player <s>
        public void SetScore(int s)
        {
            this.score = s;
        }
    }
}

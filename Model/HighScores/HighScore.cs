using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.HighScores
{
    class HighScore
    {
        private string name;
        private int score;
        public HighScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string n)
        {
            this.name = n;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void GetScore(int s)
        {
            this.score = s;
        }
    }
}

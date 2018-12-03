//-----------------------------------------------------------
//File:   HighScore.cs
//Desc:   Creates an object for storing highscore data
//        consisting of name and score
//----------------------------------------------------------- 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model.HighScores
{
    // Object for storing a player's name and score
    public class HighScore
    {
        private string name; // name of player that acheived a highscore
        private int score; // score of player that acheived a highscore
        public HighScore(string name, int score)
        {
            this.name = name; // stores name item from constructor parameter in instance variable
            this.score = score; // stores score item from constructor parameter in instance variable
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

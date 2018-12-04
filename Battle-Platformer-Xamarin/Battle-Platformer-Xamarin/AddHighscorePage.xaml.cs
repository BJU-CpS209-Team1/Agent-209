//-----------------------------------------------------------
// AddHighscorePage.xaml.cs
// David
// AddHighscorePage
//----------------------------------------------------------- 

using Royale_Platformer.Model.HighScores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battle_Platformer_Xamarin
{
    // AddHighscorePage
    // Creates a page that informs the player of their score and asks for their name
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHighscorePage : ContentPage
    {
        // stores the player's score
        int score;

        // Constructor for AddHighscorePage class
        // Takes in player's score and prompts player for name in entry
        public AddHighscorePage(int score)
        {
            InitializeComponent();
            lbl.Text = $"You achieved a high score of {score.ToString()}. Please enter your name for the leaderboard:";
            entName.Placeholder = "Your Name";
            entName.Focus();
            this.score = score;
        }

        // Event handler for completion of name entry
        // Adds score to the leaderboard and takes them to HighScoresPage
        private void EntName_Completed(object sender, EventArgs e)
        {
            HighScoresManager.AddHighScore(entName.Text, score);
            App.Current.MainPage = new HighScoresPage();
        }
    }
}
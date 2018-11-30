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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHighscorePage : ContentPage
    {
        int score;

        public AddHighscorePage(int score)
        {
            InitializeComponent();
            lbl.Text = $"You achieved a high score of {score.ToString()}. Please enter your name for the leaderboard:";
            entName.Placeholder = "Your Name";
            this.score = score;
        }

        private void BtnScore_Clicked(object sender, EventArgs e)
        {
            HighScoresManager.AddHighScore(entName.Text, score);
            App.Current.MainPage = new HighScoresPage();
        }
    }
}
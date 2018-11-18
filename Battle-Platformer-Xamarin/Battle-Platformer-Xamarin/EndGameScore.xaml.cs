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
	public partial class EndGameScore : ContentPage
	{
        int score;
        string name;
		public EndGameScore (int score)
		{
			InitializeComponent ();
            this.score = score;
            PromptPlayer();
		}

        public void PromptPlayer()
        {
            lblCongrats.Text = $"Congratulations! You scored {score} points and made it on the leaderboard!";
        }

        private void entName_Completed(object sender, EventArgs e)
        {
            name = sender as string;
            HighScoresManager scores = new HighScoresManager();
            scores.AddHighScore(name, score);
        }

        private void btnDone_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            App.Current.MainPage = new MainPage();
        }
    }
}
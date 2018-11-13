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
	public partial class HighScoresPage : ContentPage
	{
        List<HighScore> scores;
		public HighScoresPage()
		{
			InitializeComponent();
            HighScoresManager scoresClass = new HighScoresManager();
            scores = scoresClass.ReadScoresToList();
		}

        // Writes out the high scores and displays a message if there are no high scores yet
        public void ShowHighScores()
        {
            if (scores.Count == 0)
            {
                message.Text = "Sorry! There are no High Scores yet!";
                message.FontSize = 30;
                message.TextColor = Color.WhiteSmoke;
            }
            else
            {
                for (int i = 0; i < scores.Count; i++)
                {

                }
            }
        }
	}
}
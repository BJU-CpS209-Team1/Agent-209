//-----------------------------------------------------------
// HighScoresPage.xaml.cs
// David
// HighScoresPage
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
    // HighScoresPage
    // Displays the list of scores found in the scores.txt file
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HighScoresPage : ContentPage
    {

        // list of highscores
        private List<HighScore> scores;

        public HighScoresPage()
        {
            InitializeComponent();
            scores = HighScoresManager.ReadScores();
            ShowHighScores();
        }

        // Writes out the high scores and displays a message if there are no high scores yet
        public void ShowHighScores()
        {
            if (scores.Count == 0)
            {
                message.Text = "Sorry! There are no high scores yet.";
                message.FontSize = 30;
                message.TextColor = Color.WhiteSmoke;
                message.HorizontalOptions = LayoutOptions.Center;
            }
            else
            {
                int row = 0;
                for (int i = 0; i < scores.Count; i++)
                {
                    var label = new Label();
                    string name = scores[i].GetName();
                    string num = scores[i].GetScore().ToString();
                    label.Text = $"{i + 1}.  {name} - {num}";
                    label.FontSize = 30;
                    label.TextColor = Color.WhiteSmoke;
                    scoresHolder.Children.Add(label);
                    row++;
                }
            }
        }

        // Event handler for when btnBack is clicked
        // Takes the game to MainPage
        private void btnBack_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            App.Current.MainPage = new MainPage();
        }
    }
}
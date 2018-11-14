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
        private List<HighScore> scores;
        private Grid grid = new Grid();
        public HighScoresPage()
        {
            InitializeComponent();
            HighScoresManager scoresClass = new HighScoresManager();
            scores = scoresClass.ReadScoresToList();
            ShowHighScores();
        }

        // Writes out the high scores and displays a message if there are no high scores yet
        public void ShowHighScores()
        {
            if (scores.Count == 0)
            {
                message.Text = "Sorry! There are no High Scores yet.";
                message.FontSize = 30;
                message.TextColor = Color.WhiteSmoke;
                message.HorizontalOptions = LayoutOptions.Center;
            }
            else
            {
                int row = 0;
                foreach (var item in scores)
                {
                    //if (row == 5)
                    //{
                        
                    //}
                    var label = new Label();
                    string name = item.GetName();
                    string num = item.GetScore().ToString();
                    label.Text = $"{name}: {num}";
                    grid.Children.Add(label);
                    row++;
                }
                scoresGrid.Children.Add(grid);
                //int count = 0;
                //for (int row = 0; row < 5; row++)
                //{
                //    for (int col = 0; col < 2; col++)
                //    {
                //        var label = new Label();
                //        string name = scores[count].GetName();
                //        string num = scores[count].GetScore().ToString();
                //        label.Text = name + ": " + num;
                //        scoresGrid.Children.Add(label);
                //        count++;
                //    }
                //}
            }
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            App.Current.MainPage = new MainPage();
        }
    }
}
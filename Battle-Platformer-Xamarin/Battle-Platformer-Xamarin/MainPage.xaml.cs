// --------------------
// MainPage.xaml.cs
// Isaac Abrahamson
// MainPage Xaml CS File
// --------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Battle_Platformer_Xamarin
{
    // MainPage
    // This is the main menu page for the agem
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // This method plays the play button click animation and moves to next page
        private void LoadPlay(object sender, EventArgs e)
        {
            btnPlay.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnPlay.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                App.Current.MainPage = new DifficultySelection(false);
                return false;
            });
        }

        // This method plays the continue button click animation and moves to next page
        private void LoadContinue(object sender, EventArgs e)
        {
            btnContinue.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnContinue.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "latest.txt");
                if (File.Exists(PATH))
                    App.Current.MainPage = new Game(true, false, Royale_Platformer.Model.CharacterClass.Gunner);
                else
                    DisplayAlert("No Saved Game", "You do not have a saved game.", "Ok.");
                
                return false;
            });
        }

        // This method plays the schaub mode button click animation and moves to next page
        private void LoadCheat(object sender, EventArgs e)
        {
            btnCheat.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnCheat.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                App.Current.MainPage = new IntroCheat();
                return false;
            });
        }

        // This method plays the help button click animation and moves to next page
        private void LoadHelp(object sender, EventArgs e)
        {
            btnHelp.Source = "help_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnHelp.Source = "help.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                App.Current.MainPage = new HelpPage();
                return false;
            });
        }

        // This method plays the about button click animation and moves to next page
        private void LoadAbout(object sender, EventArgs e)
        {
            btnAbout.Source = "about_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnAbout.Source = "about.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                App.Current.MainPage = new AboutPage();
                return false;
            });
        }

        // This method plays the leaderboard button click animation and moves to next page
        private void LoadLeaderboard(object sender, EventArgs e)
        {
            btnLeaderboard.Source = "leaderboard_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnLeaderboard.Source = "leaderboard.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                App.Current.MainPage = new HighScoresPage();
                return false;
            });
        }
    }
}

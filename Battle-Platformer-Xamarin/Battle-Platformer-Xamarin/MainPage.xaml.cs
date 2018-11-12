using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Battle_Platformer_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

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
                App.Current.MainPage = new Game();
                return false;
            });
        }

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
                // Load game here
                App.Current.MainPage = new Game();
                return false;
            });
        }

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

        private void LoadLeaderboard(object sender, EventArgs e)
        {
            btnLeaderboard.Source = "leaderboard_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnLeaderboard.Source = "leaderboard_blue.png";
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

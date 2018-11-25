using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battle_Platformer_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DifficultySelection : ContentPage
    {
        private bool continueGame;

        public DifficultySelection(bool continueGame)
        {
            InitializeComponent();
            this.continueGame = continueGame;
        }

        private void LoadNormal(object sender, EventArgs e)
        {
            btnNormal.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnNormal.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                App.Current.MainPage = new ClassSelector(continueGame, false);
                return false;
            });
        }

        private void LoadHardcore(object sender, EventArgs e)
        {
            btnHardcore.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                btnHardcore.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "latest.txt");
                if (File.Exists(PATH))
                    App.Current.MainPage = new ClassSelector(continueGame, true);
                else
                    DisplayAlert("No Saved Game", "You do not have a saved game.", "Ok.");

                return false;
            });
        }
    }
}
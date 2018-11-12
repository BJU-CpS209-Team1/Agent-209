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

        private void LoadEasy(object sender, EventArgs e)
        {
            btnEasy.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () => {
                btnEasy.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () => {
                App.Current.MainPage = new Game();
                return false;
            });
        }

        private void LoadMedium(object sender, EventArgs e)
        {
            btnMedium.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () => {
                btnMedium.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () => {
                App.Current.MainPage = new Game();
                return false;
            });
        }

        private void LoadHard(object sender, EventArgs e)
        {
            btnHard.Source = "buttonLong_blue_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () => {
                btnHard.Source = "buttonLong_blue.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () => {
                App.Current.MainPage = new Game();
                return false;
            });
        }
    }
}

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

        private void LoadGame(object sender, EventArgs e)
        {
            btnGame.Source = "buttonLong_brown_pressed.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () => {
                btnGame.Source = "buttonLong_brown.png";
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () => {
                App.Current.MainPage = new Game();
                return false;
            });
        }
    }
}

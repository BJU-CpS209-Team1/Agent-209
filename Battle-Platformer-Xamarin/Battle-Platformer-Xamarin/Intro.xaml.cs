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
    public partial class Intro : ContentPage
    {
        bool continueGame;
        bool hardcore;

        public Intro(bool continueGame, bool hardcore)
        {
            InitializeComponent();
            this.continueGame = continueGame;
            this.hardcore = hardcore;

            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.NumberOfTapsRequired = 2;
            gestureRecognizer.Tapped += (s, e) =>
            {
                ExitVideo();
            };

            video.GestureRecognizers.Add(gestureRecognizer);
            video.Focus();

            // End of video
            Device.StartTimer(TimeSpan.FromMilliseconds(24500), () =>
            {
                ExitVideo();
                return false;
            });
        }

        public void ExitVideo()
        {
            App.Current.MainPage = new Game(continueGame, hardcore);
        }
    }
}
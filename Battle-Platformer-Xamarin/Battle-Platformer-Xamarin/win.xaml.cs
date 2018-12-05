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
	public partial class Win : ContentPage
	{
        bool skipped;
        bool isHighScore;
        int score;
		public Win (int score, bool isHighScore)
		{
			InitializeComponent ();
            this.score = score;
            this.isHighScore = isHighScore;
            skipped = false;

            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.NumberOfTapsRequired = 2;
            gestureRecognizer.Tapped += (s, e) =>
            {
                ExitVideo();
                skipped = true;
            };

            image.GestureRecognizers.Add(gestureRecognizer);
            image.Focus();

            Device.StartTimer(TimeSpan.FromMilliseconds(18000), () =>
            {
                if (!skipped) ExitVideo();
                return false;
            });
        }

        public void ExitVideo()
        {
            if (isHighScore)
                App.Current.MainPage = new AddHighscorePage(score);
            else
                App.Current.MainPage = new MainPage();
        }
    }
}
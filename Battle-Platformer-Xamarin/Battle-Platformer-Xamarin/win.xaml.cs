// --------------------
// win.xaml.cs
// Isaac Abrahamson
// Win Xaml CS File
// --------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battle_Platformer_Xamarin
{
    // Win
    // This controls the XAML page Win
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Win : ContentPage
	{
        // This holds whether the user wants to skip the video or not
        bool skipped;

        // This holds if the score is a highscore
        bool isHighScore;

        // This holds the score the user had
        int score;

        // This is the constructor for Win page
        // It will receive a score and if it is a highscore from previous page
		public Win (int score, bool isHighScore)
		{
			InitializeComponent ();
            this.score = score;
            this.isHighScore = isHighScore;
            skipped = false;

            // Provide way for user to exit video
            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.NumberOfTapsRequired = 2;
            gestureRecognizer.Tapped += (s, e) =>
            {
                ExitVideo();
                skipped = true;
            };

            image.GestureRecognizers.Add(gestureRecognizer);
            image.Focus();

            // Exit at end of video
            Device.StartTimer(TimeSpan.FromMilliseconds(18000), () =>
            {
                if (!skipped) ExitVideo();
                return false;
            });
        }

        // This method controls what to do once video has finished or been skipped
        public void ExitVideo()
        {
            if (isHighScore)
                App.Current.MainPage = new AddHighscorePage(score);
            else
                App.Current.MainPage = new MainPage();
        }
    }
}
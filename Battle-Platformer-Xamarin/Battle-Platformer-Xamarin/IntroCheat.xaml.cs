// --------------------
// IntroCheat.xaml.cs
// Isaac Abrahamson
// Intro Cheat Xaml CS File
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
    // IntroCheat
    // This is the page for the schaub mode intro
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroCheat : ContentPage
    {
        // Bool if user wants to skip video
        bool skipped;

        // Constructor for XAML page
        public IntroCheat()
        {
            InitializeComponent();
            skipped = false;

            // Provide way to skip video
            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.NumberOfTapsRequired = 2;
            gestureRecognizer.Tapped += (s, e) =>
            {
                ExitVideo();
                skipped = true;
            };

            video.GestureRecognizers.Add(gestureRecognizer);
            video.Focus();

            // Exit at end of video if not skipped
            Device.StartTimer(TimeSpan.FromMilliseconds(90000), () =>
            {
                if (!skipped) ExitVideo();
                return false;
            });
        }

        // This method moves to the next page at end of video or skip
        public void ExitVideo()
        {
            App.Current.MainPage = new Game();
        }
    }
}
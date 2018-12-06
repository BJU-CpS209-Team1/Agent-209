// --------------------
// Lose.xaml.cs
// Isaac Abrahamson
// Lose Xaml CS File
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
    // Lose
    // This controls the XAML page Lose
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lose : ContentPage
    {
        // Bool for if the user wants to skip video
        bool skipped;

        // Constructor for page
        public Lose()
        {
            InitializeComponent();
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

            // Exit at end of video if not skipped
            Device.StartTimer(TimeSpan.FromMilliseconds(8000), () =>
            {
                if (!skipped) ExitVideo();
                return false;
            });
        }

        // This method will move to the next page at end of video or on skip
        public void ExitVideo()
        {
            App.Current.MainPage = new MainPage();
        }
    }
}
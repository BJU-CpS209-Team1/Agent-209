// --------------------
// Intro.xaml.cs
// Isaac Abrahamson
// Intro Xaml CS File
// --------------------

using Royale_Platformer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battle_Platformer_Xamarin
{
    // Intro
    // This is the class for the intro video
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Intro : ContentPage
    {
        // Is the user starting a new game or loading a saved one
        bool continueGame;

        // Is the game hardcore or normal
        bool hardcore;

        // Does the user want to skip intro video
        bool skipped;

        // Holds the character class of the player
        CharacterClass charClass;

        // Constructor for intro page
        // Takes whether the user is loading a new game or not, the difficulty, and the class
        public Intro(bool continueGame, bool hardcore, CharacterClass charClass)
        {
            InitializeComponent();
            this.continueGame = continueGame;
            this.hardcore = hardcore;
            this.charClass = charClass;
            this.skipped = false;

            // Provide way to exit video
            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.NumberOfTapsRequired = 2;
            gestureRecognizer.Tapped += (s, e) =>
            {
                ExitVideo();
                skipped = true;
            };

            video.GestureRecognizers.Add(gestureRecognizer);
            video.Focus();

            // Exit at end of video
            Device.StartTimer(TimeSpan.FromMilliseconds(24500), () =>
            {
                if(!skipped) ExitVideo();
                return false;
            });
        }

        // This moves to the game if video is done or is skipped
        public void ExitVideo()
        {
            App.Current.MainPage = new Game(continueGame, hardcore, charClass);
        }
    }
}
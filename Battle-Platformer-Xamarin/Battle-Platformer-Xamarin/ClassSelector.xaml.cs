// --------------------
// ClassSelector.xaml.cs
// Isaac Abrahamson
// ClassSelector Xaml CS File
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
    // ClassSelector
    // Allows user to choose class
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassSelector : ContentPage
    {
        // Is this a saved game
        bool continueGame;

        // Difficulty of game
        bool hardcore;

        // Constructor
        // Takes if it is saved/new and the difficulty
        public ClassSelector(bool continueGame, bool hardcore)
        {
            InitializeComponent();
            this.continueGame = continueGame;
            this.hardcore = hardcore;
        }

        // This method plays animation for gunner button and moves to next page
        private void BtnGunner_Clicked(object sender, EventArgs e)
        {
            btnGunner.Source = "gunnerAlt.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(1250), () =>
            {
                App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Gunner);
                return false;
            });
        }

        // This method plays animation for support button and moves to next page
        private void BtnSupport_Clicked(object sender, EventArgs e)
        {
            btnSupport.Source = "supportAlt.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(1250), () =>
            {
                App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Support);
                return false;
            });
        }

        // This method plays animation for tank button and moves to next page
        private void BtnTank_Clicked(object sender, EventArgs e)
        {
            btnTank.Source = "tankAlt.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(2500), () =>
            {
                App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Tank);
                return false;
            });
        }
    }
}
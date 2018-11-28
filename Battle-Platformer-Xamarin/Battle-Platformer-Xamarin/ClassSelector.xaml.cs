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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassSelector : ContentPage
    {
        bool continueGame;
        bool hardcore;

        public ClassSelector(bool continueGame, bool hardcore)
        {
            InitializeComponent();
            this.continueGame = continueGame;
            this.hardcore = hardcore;
        }

        private void BtnGunner_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Gunner);
        }

        private void BtnSupport_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Support);
        }

        private void BtnTank_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Tank);
        }
    }
}
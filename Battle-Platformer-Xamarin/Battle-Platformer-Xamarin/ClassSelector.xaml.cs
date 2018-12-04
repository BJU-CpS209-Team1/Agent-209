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
            btnGunner.Source = "gunnerAlt.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(1250), () =>
            {
                App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Gunner);
                return false;
            });
        }

        private void BtnSupport_Clicked(object sender, EventArgs e)
        {
            btnSupport.Source = "supportAlt.png";
            Device.StartTimer(TimeSpan.FromMilliseconds(1250), () =>
            {
                App.Current.MainPage = new Intro(continueGame, hardcore, CharacterClass.Support);
                return false;
            });
        }

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
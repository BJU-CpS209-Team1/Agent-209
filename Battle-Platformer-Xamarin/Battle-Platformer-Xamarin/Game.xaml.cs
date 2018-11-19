using Royale_Platformer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Urho;
using Urho.Forms;


namespace Battle_Platformer_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        bool continueGame;
        bool hardcore;

        public Game(bool continueGame, bool hardcore)
        {
            InitializeComponent();
            this.continueGame = continueGame;
            this.hardcore = hardcore;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            GameApp game = await surfaceGame.Show<GameApp>(new Urho.ApplicationOptions(assetsFolder: "GameData") { ResizableWindow = true });

            if (continueGame) game.Load("latest.txt");
           
        }
    }
}
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
    public partial class Game : ContentPage
    {
        bool continueGame = false;

        public Game(bool continueGame)
        {
            InitializeComponent();
            this.continueGame = continueGame;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
                GameApp game = await surfaceGame.Show<GameApp>(new Urho.ApplicationOptions(assetsFolder: "GameData"));
            if (continueGame)
                game.Load("latest.txt");
        }
    }
}
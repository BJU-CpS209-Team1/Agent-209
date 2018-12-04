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
using Royale_Platformer.Model.HighScores;

namespace Battle_Platformer_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        bool continueGame;
        bool hardcore;
        CharacterClass charClass;
        bool cheat = false;

        public Game(bool continueGame, bool hardcore, CharacterClass charClass)
        {
            InitializeComponent();
            this.continueGame = continueGame;
            this.hardcore = hardcore;
            this.charClass = charClass;
        }

        // Cheat mode
        public Game()
        {
            InitializeComponent();
            continueGame = false;
            hardcore = true;
            charClass = CharacterClass.Schaub;
            cheat = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            GameApp game = await surfaceGame.Show<GameApp>(new Urho.ApplicationOptions(assetsFolder: "GameData")
            {
                ResizableWindow = true,
                AdditionalFlags = $"{hardcore.ToString()},{continueGame.ToString()},{charClass.ToString()},{cheat.ToString()}"
            });

            game.Restart = () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await game.Exit();
                    App.Current.MainPage = new MainPage();
                    App.Utilities.SetFullscreen();
                });
                return false;
            };

            game.HandleWin = () =>
            {
                int score = game.PlayerCharacter.Score;
                bool isHighscore = HighScoresManager.CheckScore(score);
         
                // Exit game
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await game.Exit();
                    App.Current.MainPage = new Win(score, isHighscore);
                    App.Utilities.SetFullscreen();
                });
                return false;
            };
            
            game.HandleLose = () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await game.Exit();
                    App.Current.MainPage = new Lose();
                    App.Utilities.SetFullscreen();
                });
                return false;
            };

            if (continueGame) game.Load("latest.txt");
        }
    }
}
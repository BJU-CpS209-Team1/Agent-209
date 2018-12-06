// --------------------
// Game.xaml.cs
// Isaac Abrahamson, Elias Watson
// Game Xaml CS File
// --------------------

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
using FormsVideoLibrary;

namespace Battle_Platformer_Xamarin
{
    // Game
    // This is the page the game will be on
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        // Is this a new or saved game
        bool continueGame;

        // The difficulty of the game
        bool hardcore;

        // The Player class
        CharacterClass charClass;

        // Is this game in schaub mode
        bool cheat = false;

        // Constructor for normal and hardcore game
        // recieves if it is a new game or saved game, the difficulty, and the player class
        public Game(bool continueGame, bool hardcore, CharacterClass charClass)
        {
            InitializeComponent();
            this.continueGame = continueGame;
            this.hardcore = hardcore;
            this.charClass = charClass;

            // Play music in background video because Urho will not play sounds on the second game
            VideoPlayer music = new VideoPlayer()
            {
                Source = VideoSource.FromResource("GameData/sounds/gameLoop.mp4"),
                AreTransportControlsEnabled = false,
                IsVisible = false
            };
            layout.Children.Add(music);
        }

        // Constructor for Schaub Mode
        // This will be called by the schaub mode button and does not need any parameters
        public Game()
        {
            InitializeComponent();
            continueGame = false;
            hardcore = true;
            charClass = CharacterClass.Schaub;
            cheat = true;

            // Play music in background video because Urho will not play sounds on the second game
            VideoPlayer music = new VideoPlayer()
            {
                Source = VideoSource.FromResource("GameData/sounds/schaubGame.mp4"),
                AreTransportControlsEnabled = false,
                IsVisible = false
            };
            layout.Children.Add(music);
        }

        // This method is by Urho and controls the game being on the page
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            GameApp game = await surfaceGame.Show<GameApp>(new Urho.ApplicationOptions(assetsFolder: "GameData")
            {
                ResizableWindow = true,
                AdditionalFlags = $"{hardcore.ToString()},{continueGame.ToString()},{charClass.ToString()},{cheat.ToString()}"
            });

            // This method is passed into the game and will be called on restart
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

            // This method is passed into the game and will be called on win
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

            // This method is passed into the game and will be called on lose
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

            // Load saved game
            if (continueGame) game.Load("latest.txt");
        }
    }
}
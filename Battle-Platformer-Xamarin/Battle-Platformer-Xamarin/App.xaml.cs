// --------------------
// App.xaml.cs
// Isaac Abrahamson
// App Xaml CS File
// --------------------

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Battle_Platformer_Xamarin
{
    // App
    // This is the base Xamarin forms file
    public partial class App : Application
    {
        // Constructor
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        // This holds a custom rendering utility
        public static IUtilities Utilities { get; private set; }

        // This initializes the custom rendering utility
        public static void Init(IUtilities utilities)
        {
            App.Utilities = utilities;
        }
    }
}

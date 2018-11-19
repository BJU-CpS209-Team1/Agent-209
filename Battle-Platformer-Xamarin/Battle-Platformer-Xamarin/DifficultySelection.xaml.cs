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
    public partial class DifficultySelection : ContentPage
    {
        public DifficultySelection(bool continueGame)
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                App.Current.MainPage = new Game(continueGame);
                return false;
            });
        }
    }
}
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
    public partial class IntroCheat : ContentPage
    {
        public IntroCheat()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(90000), () =>
            {
                ExitVideo();
                return false;
            });
        }

        public void ExitVideo()
        {
            App.Current.MainPage = new Game();
        }
    }
}
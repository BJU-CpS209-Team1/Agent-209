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
    public partial class Lose : ContentPage
    {
        public Lose()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(2500), () =>
            {
                App.Current.MainPage = new MainPage();
                return false;
            });
        }
    }
}
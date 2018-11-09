using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Battle_Platformer_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGame_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Game();
        }
    }
}

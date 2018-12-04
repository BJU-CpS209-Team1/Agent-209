//-----------------------------------------------------------
// HelpPage.xaml.cs
// David
// HelpPage
//----------------------------------------------------------- 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battle_Platformer_Xamarin
{
    // HelpPage
    // Displays HelpPage.xaml
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HelpPage : ContentPage
	{
		public HelpPage ()
		{
			InitializeComponent ();
		}

        // Event handler for when btnBack is clicked
        // Takes the game to MainPage
        private void btnBack_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            App.Current.MainPage = new MainPage();
        }
    }
}
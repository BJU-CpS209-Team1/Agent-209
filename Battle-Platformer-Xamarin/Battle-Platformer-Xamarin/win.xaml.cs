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
	public partial class Win : ContentPage
	{
		public Win (int score, bool isHighScore)
		{
			InitializeComponent ();

            Device.StartTimer(TimeSpan.FromMilliseconds(2500), () =>
            {
                if (isHighScore)
                    App.Current.MainPage = new AddHighscorePage(score);
                else
                    App.Current.MainPage = new MainPage();
                return false;
            });            
        }
	}
}
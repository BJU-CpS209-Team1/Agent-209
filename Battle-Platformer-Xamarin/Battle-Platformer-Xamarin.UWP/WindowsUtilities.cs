using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace Battle_Platformer_Xamarin.UWP
{
    class WindowsUtilities : IUtilities
    {
        public void SetFullscreen() { ApplicationView.GetForCurrentView().TryEnterFullScreenMode(); }
    }
}

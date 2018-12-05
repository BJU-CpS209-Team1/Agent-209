// --------------------
// WindowsUtilities.cs
// IsaacAbrahamson
// Holds UWP utilities
// --------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace Battle_Platformer_Xamarin.UWP
{
    // WindowsUtilities
    // Manages UWP utilities
    class WindowsUtilities : IUtilities
    {

        // Makes the application fullscreen
        public void SetFullscreen()
        {
            ApplicationView.GetForCurrentView().ExitFullScreenMode();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Maximized;
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }
    }
}

// --------------------
// IVideoPicker.cs
// Xamarin
// This is a library from the Xamarin Forms sample
// https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/VideoPlayerDemos
// --------------------

using System;
using System.Threading.Tasks;

namespace FormsVideoLibrary
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}

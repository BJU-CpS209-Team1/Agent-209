// --------------------
// IVideoPlayerController.cs
// Xamarin
// This is a library from the Xamarin Forms sample
// https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/VideoPlayerDemos
// --------------------

using System;

namespace FormsVideoLibrary
{ 
    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }
    }
}

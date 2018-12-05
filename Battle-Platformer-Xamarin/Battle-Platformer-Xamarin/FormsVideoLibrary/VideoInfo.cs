// --------------------
// VideoInfo.cs
// Xamarin
// This is a library from the Xamarin Forms sample
// https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/VideoPlayerDemos
// --------------------

using FormsVideoLibrary;

namespace VideoPlayerDemos
{
    public class VideoInfo
    {
        public string DisplayName { set; get; }

        public VideoSource VideoSource { set; get; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}

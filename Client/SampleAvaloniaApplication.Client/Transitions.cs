using Avalonia.Animation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client
{
    public static class Transitions
    {
        public static IPageTransition Fade => new CrossFade(TimeSpan.FromMilliseconds(200));

        public static IPageTransition Slide => new PageSlide(TimeSpan.FromMilliseconds(200));
    }
}

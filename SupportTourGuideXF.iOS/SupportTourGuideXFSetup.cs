using System;
using Xamarin.Forms.Platform.iOS;

namespace SupportTourGuideXF.iOS
{
    public static class SupportTourGuideXFSetup
    {
        public static FormsApplicationDelegate AppDelegate;

        public static void Initialize(FormsApplicationDelegate _AppDelegate)
        {
            AppDelegate = _AppDelegate;
        }
    }
}
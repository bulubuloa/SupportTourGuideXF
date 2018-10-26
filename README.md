# SupportTourGuideXF
 SupportTourGuideXF is an Android/iOS library, write by c#, based on Xamarin.Forms. It lets you add pointer, overlay and tooltip easily, guiding users on how to use your app. 

Unavailable on NuGet: comming soon

**Setup for iOS project**

    Add to AppDelegate before LoadApplication
      SupportTourGuideXFSetup.Initialize(this);
 

**Setup for Android project** 

    Add to MainActivity before LoadApplication
      SupportTourGuideXFSetup.Initialize(this);


## USAGE
1. Add to code behide

            var builder = new TourGuideBuilder();
            var tourGuide = builder
                    .AddStep(EntryUserName, "Type username here")
                    .AddStep(EntryPassword, "Type password here")
                    .Build();
            tourGuide.StartTour();

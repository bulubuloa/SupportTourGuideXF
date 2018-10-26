using System;
using SupportTourGuideXF.Behaviors;
using Xamarin.Forms;

namespace SupportTourGuideXF.Animations
{
    public class AnimateScaleBehavior : AnimateFoldBehaviorBase
    {
        protected override void ExecuteAnimation(double start, double end, uint runningTime)
        {
            var animation = new Animation(d => AssociatedObject.Scale = d, start, end, Easing.SinOut);
            animation.Commit(AssociatedObject, "Unfold", length: runningTime,finished: (d, b) =>
            {
                if (AssociatedObject.Scale.Equals(FoldInPosition))
                {
                    AssociatedObject.IsVisible = false;
                }
            });
        }

        protected override void Init(bool viewIsInitialized)
        {
            if (viewIsInitialized)
            {
                FoldOutPosition = 1;
                FoldInPosition = 0;
                AssociatedObject.Scale = FoldInPosition;
            }
        }
    }
}
using System;
using SupportTourGuideXF.Behaviors;
using SupportTourGuideXF.Extensions;
using Xamarin.Forms;

namespace SupportTourGuideXF.Animations
{
    public class AnimateSlideDownBehavior : AnimateFoldBehaviorBase
    {
        protected override void ExecuteAnimation(double start, double end, uint runningTime)
        {
            var animation = new Animation(d => AssociatedObject.TranslationY = d, start, end, Easing.SinOut);
            animation.Commit(AssociatedObject, "Unfold", length: runningTime,finished: (d, b) =>
            {
                if (AssociatedObject.TranslationY.Equals(FoldInPosition))
                {
                    AssociatedObject.IsVisible = false;
                }
            });
        }

        protected override void Init(bool viewIsInitialized)
        {
            if (viewIsInitialized)
            {
                var parentView = AssociatedObject.GetParentView();
                if (parentView != null)
                {
                    FoldInPosition = -parentView.Height;
                    AssociatedObject.TranslationY = FoldInPosition;
                }
            }
        }
    }
}
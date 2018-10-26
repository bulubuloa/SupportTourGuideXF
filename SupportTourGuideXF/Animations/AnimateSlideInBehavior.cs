using System;
using SupportTourGuideXF.Behaviors;
using SupportTourGuideXF.Extensions;
using Xamarin.Forms;

namespace SupportTourGuideXF.Animations
{
    public class AnimateSlideInBehavior : AnimateFoldBehaviorBase
    {
        protected override void ExecuteAnimation(double start, double end, uint runningTime)
        {
            var animation = new Animation(d => AssociatedObject.TranslationX = d, start, end, Easing.SinOut);
            animation.Commit(AssociatedObject, "Unfold", length: runningTime,finished: (d, b) =>
            {
                if (AssociatedObject.TranslationX.Equals(FoldInPosition))
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
                    FoldInPosition = -parentView.Width;
                    AssociatedObject.TranslationX = FoldInPosition;
                }
            }
        }
    }
}
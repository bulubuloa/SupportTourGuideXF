using System;
using Xamarin.Forms;

namespace SupportTourGuideXF.Behaviors
{
    public abstract class AnimateFoldBehaviorBase : ViewInitializedBehaviorBase<View>
    {
        protected double FoldInPosition;
        protected double FoldOutPosition;

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.IsVisible = false;
        }

        private void ExecuteAnimation(bool show)
        {
            if (show)
            {
                AssociatedObject.IsVisible = true;
                ExecuteAnimation(FoldInPosition, FoldOutPosition, (uint)FoldOutTime);
            }
            else
            {
                ExecuteAnimation(FoldOutPosition, FoldInPosition, (uint)FoldInTime);
            }
        }

        protected abstract void ExecuteAnimation(double start, double end, uint runningTime);

        #region IsVisible Attached Dependency Property      

        public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(bool), typeof(AnimateFoldBehaviorBase),false, BindingMode.OneWay,propertyChanged: OnIsVisibleChanged);
        public bool IsVisible
        {
            get => (bool)GetValue(IsVisibleProperty);
            set
            {
                SetValue(IsVisibleProperty, value);
            }
        }

        private static void OnIsVisibleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var thisObj = bindable as AnimateFoldBehaviorBase;
            thisObj?.ExecuteAnimation((bool)newValue);
        }

        #endregion

        #region FoldInTime Attached Dependency Property      
        public static readonly BindableProperty FoldInTimeProperty = BindableProperty.Create(nameof(FoldInTime), typeof(int), typeof(AnimateFoldBehaviorBase),150);
        public int FoldInTime
        {
            get => (int)GetValue(FoldInTimeProperty);
            set
            {
                SetValue(FoldInTimeProperty, value);
            }
        }
        #endregion

        #region FoldOutTime Attached Dependency Property      
        public static readonly BindableProperty FoldOutTimeProperty = BindableProperty.Create(nameof(FoldOutTime), typeof(int), typeof(AnimateFoldBehaviorBase),250);
        public int FoldOutTime
        {
            get => (int)GetValue(FoldOutTimeProperty);
            set
            {
                SetValue(FoldOutTimeProperty, value);
            }
        }
        #endregion

    }
}

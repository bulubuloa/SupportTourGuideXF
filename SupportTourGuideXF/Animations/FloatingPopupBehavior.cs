using System;
using SupportTourGuideXF.Behaviors;
using SupportTourGuideXF.Controls;
using Xamarin.Forms;

namespace SupportTourGuideXF.Animations
{
    public class FloatingPopupBehavior : BindableBehaviorBase<View>
    {
        private IGestureRecognizer _gestureRecognizer;

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            _gestureRecognizer = new TapGestureRecognizer { Command = new Command(ShowControl) };
            AssociatedObject.GestureRecognizers.Add(_gestureRecognizer);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
            AssociatedObject.GestureRecognizers.Remove(_gestureRecognizer);
        }

        private void ShowControl()
        {
            if (AssociatedObject.IsVisible && AssociatedObject.Opacity > 0.01)
            {
                PopupControl?.ShowMessageFor(AssociatedObject, MessageText, new Point(Dx, Dy));
            }
        }

        #region PopupControl Attached Dependency Property      

        public static readonly BindableProperty PopupControlProperty = BindableProperty.Create(nameof(PopupControl), typeof(IFloatingPopup), typeof(FloatingPopupBehavior),default(IFloatingPopup));
        public IFloatingPopup PopupControl
        {
            get { return (IFloatingPopup)GetValue(PopupControlProperty); }
            set { SetValue(PopupControlProperty, value); }
        }
        #endregion

        #region MessageText Attached Dependency Property      
        public static readonly BindableProperty MessageTextProperty = BindableProperty.Create(nameof(MessageText), typeof(string), typeof(FloatingPopupBehavior),default(string));
        public string MessageText
        {
            get { return (string)GetValue(MessageTextProperty); }
            set { SetValue(MessageTextProperty, value); }
        }
        #endregion


        #region Dx Attached Dependency Property      
        public static readonly BindableProperty DxProperty = BindableProperty.Create(nameof(Dx), typeof(int), typeof(FloatingPopupBehavior),default(int));
        public int Dx
        {
            get { return (int)GetValue(DxProperty); }
            set { SetValue(DxProperty, value); }
        }
        #endregion

        #region Dy Attached Dependency Property      
        public static readonly BindableProperty DyProperty = BindableProperty.Create(nameof(Dy), typeof(int), typeof(FloatingPopupBehavior),default(int));
        public int Dy
        {
            get { return (int)GetValue(DyProperty); }
            set { SetValue(DyProperty, value); }
        }
        #endregion
    }
}

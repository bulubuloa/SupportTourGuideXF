using System;
using Xamarin.Forms;

namespace SupportTourGuideXF.Behaviors
{
    public abstract class BindableBehaviorBase<T> : Behavior<T> where T : VisualElement
    {
        protected T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            AssociatedObject = bindable;
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(T bindable)
        {
            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
            base.OnDetachingFrom(bindable);
            AssociatedObject = null;
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            if (AssociatedObject != null)
            {
                BindingContext = AssociatedObject.BindingContext;
            }
        }
    }
}
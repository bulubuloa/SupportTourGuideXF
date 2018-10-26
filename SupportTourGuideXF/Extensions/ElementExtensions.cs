using System;
using Xamarin.Forms;

namespace SupportTourGuideXF.Extensions
{
    public static class ElementExtensions
    {
        public static VisualElement GetParentView(this Element element)
        {
            var parent = element;
            VisualElement parentView = null;
            if (parent != null)
            {
                do
                {
                    parent = parent.Parent;
                    parentView = parent as VisualElement;
                } while (parentView?.Width <= 0 && parent.Parent != null);
            }

            return parentView;
        }

        public static Point GetAbsoluteLocation(this VisualElement e)
        {
            var result = new Point(e.X, e.Y);
            var parent = e.Parent;
            while (parent != null)
            {
                var view = parent as VisualElement;
                if (view != null)
                {
                    result.X += view.X;
                    result.Y += view.Y;
                }
                parent = parent.Parent;
            }
            return result;
        }
    }
}
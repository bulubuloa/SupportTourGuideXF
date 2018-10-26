using System;
using System.Linq;
using CoreGraphics;
using SupportTourGuideXF.DependencyServices;
using SupportTourGuideXF.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(IDisplayToolExtended))]
namespace SupportTourGuideXF.iOS
{
    public class IDisplayToolExtended : IDisplayTool
    {
        public UIWindow GetCurrentWindow()
        {
            UIViewController viewController = null;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            if (window == null)
                throw new InvalidOperationException("There's no current active window");

            if (window.WindowLevel == UIWindowLevel.Normal)
                viewController = window.RootViewController;

            if (viewController == null)
            {
                window = UIApplication.SharedApplication.Windows.OrderByDescending(w => w.WindowLevel).FirstOrDefault(w => w.RootViewController != null && w.WindowLevel == UIWindowLevel.Normal);
                if (window == null)
                    throw new InvalidOperationException("Could not find current view controller");
                else
                    viewController = window.RootViewController;
            }

            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            return (UIWindow)viewController.View.Superview;
        }

        public void IF_ShowView(View view, Point point, Action completeAction)
        {
            var renderer = Platform.CreateRenderer(view);
            var size = new CoreGraphics.CGRect(point.X, point.Y, 100, 50);
            renderer.NativeView.Frame = size;
            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;
            renderer.Element.Layout(size.ToRectangle());
            var nativeView = renderer.NativeView;
            nativeView.SetNeedsLayout();
            nativeView.Layer.CornerRadius = 5;

            var window = GetCurrentWindow();

            var coverView = new UIView(new CGRect(0, 0, window.Bounds.Width, window.Bounds.Height));
            coverView.BackgroundColor = UIColor.Gray.ColorWithAlpha(0.5f);
            coverView.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                UIView.Animate(duration: 0.2, delay: 0, options: UIViewAnimationOptions.CurveEaseInOut,
                animation: () =>
                {
                    nativeView.Frame = new CGRect(size.X, size.Y, 0, 0);
                    coverView.AddSubview(nativeView);
                },
                completion: () =>
                {
                    coverView.RemoveFromSuperview();
                    if (completeAction != null)
                        completeAction();
                });
            }));
            window.AddSubview(coverView);

            nativeView.Frame = new CGRect(size.X + 50, size.Y + 25, 0, 0);

            UIView.Animate(duration: 0.1, delay: 0, options: UIViewAnimationOptions.CurveEaseOut,
            animation: () =>
            {
                nativeView.Frame = new CGRect(size.X, size.Y, size.Width, 50);
                coverView.AddSubview(nativeView);
            },
            completion: () =>
            {

            });
        }
    }
}

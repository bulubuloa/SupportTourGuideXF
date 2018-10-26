using System;
using System.Threading.Tasks;
using SupportTourGuideXF.Extensions;
using Xamarin.Forms;

namespace SupportTourGuideXF.Animations
{
    public class FloatingPopupDisplayStrategy
    {
        private readonly Label _infoText;
        private readonly View _overallView;
        private readonly View _messageView;

        public FloatingPopupDisplayStrategy(Label infoText, View overallView, View messageView)
        {
            _infoText = infoText;
            _overallView = overallView;
            _messageView = messageView;

            _overallView.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(ResetControl) });
            _overallView.SizeChanged += (sender, args) => { ResetControl(); };
        }

        public virtual async Task ShowMessageFor(VisualElement parentElement, string text, Point? delta = null)
        {
            _infoText.Text = text;
            _overallView.IsVisible = true;

            // IOS apparently needs to have some time to layout the grid first
            // Windows needs the size of the message to update first
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Windows) 
                await Task.Delay(25);

            _messageView.Scale = 0;

            var gridLocation = _messageView.GetAbsoluteLocation();
            var parentLocation = parentElement.GetAbsoluteLocation();

            _messageView.TranslationX = parentLocation.X - gridLocation.X -
                                       _messageView.Width + parentElement.Width +
                                       delta?.X ?? 0;
            _messageView.TranslationY = parentLocation.Y - gridLocation.Y +
                                       parentElement.Height + delta?.Y ?? 0;

            _messageView.Opacity = 1;
            ExecuteAnimation(0, 1, 250);
        } 

        private void ExecuteAnimation(double start, double end, uint runningTime)
        {
            var animation = new Animation(
              d => _messageView.Scale = d, start, end, Easing.SpringOut);

            animation.Commit(_messageView, "Unfold", length: runningTime);
        }

        private void ResetControl()
        {
            if (_messageView.Opacity != 0)
            {
                _messageView.Opacity = 0;
                _overallView.IsVisible = false;
            }
        }
    }
}

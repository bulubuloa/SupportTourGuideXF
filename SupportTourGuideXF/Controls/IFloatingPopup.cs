using System;
using Xamarin.Forms;

namespace SupportTourGuideXF.Controls
{
    public interface IFloatingPopup
    {
        void ShowMessageFor(VisualElement parentElement, string text, Point? delta = null);
    }
}
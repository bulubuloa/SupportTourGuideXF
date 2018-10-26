using System;
using System.Collections.Generic;
using SupportTourGuideXF.Animations;
using SupportTourGuideXF.Controls;
using Xamarin.Forms;

namespace SupportTourGuideDemo
{
    public partial class FloatingPopupControl : Grid
    {
        private readonly FloatingPopupDisplayStrategy _strategy;

        public FloatingPopupControl()
        {
            InitializeComponent();
           // _strategy = new FloatingPopupDisplayStrategy(InfoText, this, MessageGrid);
        }

        public async void ShowMessageFor(VisualElement parentElement, string text, Point? delta = null)
        {
            await _strategy.ShowMessageFor(parentElement, text, delta); new NotImplementedException();
        }
    }
}
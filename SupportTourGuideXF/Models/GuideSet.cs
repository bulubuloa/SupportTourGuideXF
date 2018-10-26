using System;
namespace SupportTourGuideXF.Models
{
    public class GuideSet
    {
        public Xamarin.Forms.View Widget { set; get; }
        public string Text { set; get; }

        public GuideSet(Xamarin.Forms.View _Widget, string _Text)
        {
            Widget = _Widget;
            Text = _Text;
        }
    }
}
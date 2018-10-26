using System;
namespace SupportTourGuideXF.Models
{
    public class TourGuideBuilder
    {
        private TourGuide tourGuide = new TourGuide();

        public TourGuideBuilder()
        {
        }

        public TourGuideBuilder AddStep(Xamarin.Forms.View _Widget, string _Text)
        {
            tourGuide.guideSets.Add(new GuideSet(_Widget, _Text));
            return this;
        }

        public TourGuide Build()
        {
            return tourGuide;
        }
    }
}
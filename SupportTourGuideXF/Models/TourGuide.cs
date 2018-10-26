using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupportTourGuideXF.DependencyServices;
using SupportTourGuideXF.Extensions;
using Xamarin.Forms;

namespace SupportTourGuideXF.Models
{
    public class TourGuide
    {
        public List<GuideSet> guideSets { set; get; }

        public TourGuide()
        {
            guideSets = new List<GuideSet>();
        }

        private Action InitAction(int indexOfItem)
        {
            if (indexOfItem == guideSets.Count)
                return null;

            var currentItem = guideSets[indexOfItem];
            return new Action(async () =>
            {
                await Task.Delay(100);

                var viewShow = new StackLayout() 
                { 
                    BackgroundColor = Color.Teal,
                };
                var message = new Label()
                {
                    Text = currentItem.Text,
                    TextColor = Color.White
                };
                viewShow.Children.Add(message);

                var pointNative = currentItem.Widget.GetAbsoluteLocation();
                var nextAction = InitAction(indexOfItem + 1);
                DependencyService.Get<IDisplayTool>().IF_ShowView(viewShow,pointNative ,nextAction);
            });
        }
        public void StartTour()
        {
            var currentAction = InitAction(0);
            if(currentAction!=null)
                currentAction();
        }
    }
}
using System.Diagnostics;
using System.Threading.Tasks;
using SupportTourGuideXF.Extensions;
using SupportTourGuideXF.Models;
using Xamarin.Forms;

namespace SupportTourGuideDemo
{
    public partial class MainPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var builder = new TourGuideBuilder();
            var tourGuide = builder.AddStep(EntryUserName, "Type username here")
                   .AddStep(EntryPassword, "Type password here")
                   .Build();

            tourGuide.StartTour();
        }

        public MainPage()
        {
            InitializeComponent();

            Task.Delay(2000).ContinueWith((arg) =>
            {
                Debug.WriteLine(EntryUserName.GetAbsoluteLocation().ToString());
                Debug.WriteLine(EntryPassword.GetAbsoluteLocation().ToString());
            });

        }
    }
}

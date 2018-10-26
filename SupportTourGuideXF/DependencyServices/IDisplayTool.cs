using System;
namespace SupportTourGuideXF.DependencyServices
{
    public interface IDisplayTool
    {
        void IF_ShowView(Xamarin.Forms.View view, Xamarin.Forms.Point point, Action completeAction);
    }
}
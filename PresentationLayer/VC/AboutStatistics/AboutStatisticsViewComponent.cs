using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.AboutStatistics
{
    public class AboutStatisticsViewComponent:ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}

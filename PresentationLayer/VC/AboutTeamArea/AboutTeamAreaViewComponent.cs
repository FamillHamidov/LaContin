using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.AboutTeamArea
{
    public class AboutTeamAreaViewComponent:ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}

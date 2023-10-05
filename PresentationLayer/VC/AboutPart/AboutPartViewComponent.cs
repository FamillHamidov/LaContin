using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.AboutPart
{
    public class AboutPartViewComponent:ViewComponent
    {
        private readonly IAboutService _aboutService;

		public AboutPartViewComponent(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public  Task<IViewComponentResult> InvokeAsync()
        {
            var about = _aboutService.GetAll();
            return Task.FromResult<IViewComponentResult>(View(about));
        }
    }
}

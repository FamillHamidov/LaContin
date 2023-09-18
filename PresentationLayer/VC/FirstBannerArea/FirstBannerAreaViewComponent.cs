using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.FirstBannerArea
{
	public class FirstBannerAreaViewComponent:ViewComponent
	{
		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult<IViewComponentResult>(View());
		}
	}
}

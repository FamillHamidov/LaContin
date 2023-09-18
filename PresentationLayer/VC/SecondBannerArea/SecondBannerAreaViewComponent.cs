using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.SecondBannerArea
{
	public class SecondBannerAreaViewComponent:ViewComponent
	{
		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult<IViewComponentResult>(View());
		}
	}
}

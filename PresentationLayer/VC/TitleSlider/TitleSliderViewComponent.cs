using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.TitleSlider
{
	public class TitleSliderViewComponent:ViewComponent
	{
		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult<IViewComponentResult>(View());
		}
	}
}

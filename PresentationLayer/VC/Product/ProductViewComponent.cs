using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.Product
{
	public class ProductViewComponent:ViewComponent
	{
		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult<IViewComponentResult>(View());
		}
	}
}

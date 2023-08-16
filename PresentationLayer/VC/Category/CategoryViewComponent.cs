using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.Category
{
	public class CategoryViewComponent:ViewComponent
	{
		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult<IViewComponentResult>(View());
		}
	}
}

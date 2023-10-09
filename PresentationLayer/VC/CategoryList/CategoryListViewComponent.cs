using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.CategoryList
{
	public class CategoryListViewComponent:ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public CategoryListViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public Task<IViewComponentResult> InvokeAsync()
		{
			var categories = _categoryService.GetAll();
			return Task.FromResult<IViewComponentResult>(View(categories));
		}
	}
}

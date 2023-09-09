using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.Product
{
	public class ProductViewComponent:ViewComponent
	{
		private readonly IProductService _productService;

        public ProductViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public Task<IViewComponentResult> InvokeAsync()
		{
			var product = _productService.GetAll();
			return Task.FromResult<IViewComponentResult>(View(product));
		}
	}
}

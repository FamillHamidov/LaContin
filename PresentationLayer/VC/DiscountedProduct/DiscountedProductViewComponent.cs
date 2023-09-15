using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.DiscountedProduct
{
    public class DiscountedProductViewComponent:ViewComponent
    {
        private readonly IProductService _productService;

        public DiscountedProductViewComponent(IProductService productService)
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

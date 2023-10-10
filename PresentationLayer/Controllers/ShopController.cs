using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly Context _context;
        public ShopController(Context context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }
        public IActionResult Index(int id)
        {
            var products = _context.Products.Where(x => x.CategoryId == id).ToList();
            return View(products);
        }
        public IActionResult ShopDetail(int id)
        {
            var product = _productService.GetById(id);
            return View(product);
        }
    }
}

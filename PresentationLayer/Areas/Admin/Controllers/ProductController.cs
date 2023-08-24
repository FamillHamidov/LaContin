using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly Context _context;

		public ProductController(IProductService productService, Context context, ICategoryService categoryService)
		{
			_productService = productService;
			_context = context;
			_categoryService = categoryService;
		}

		public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }
        [HttpGet]
        public IActionResult NewProduct()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll().Where(x=>x.Status==true)
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            
            ViewBag.categories=categories;
            return View();
        }
        [HttpPost]
        public IActionResult NewProduct(Product product)
        {
            _productService.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetById(id);
            _productService.Delete(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product=_productService.GetById(id);
            List<SelectListItem> categories = (from x in _categoryService.GetAll().Where(x => x.Status == true)
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

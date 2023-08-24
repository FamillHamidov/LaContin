using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly Context _context;

        public HomeController(ICategoryService categoryService, Context context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        public IActionResult Index()
		{
			var categories = _categoryService.GetAll();
			return View(categories);
		}
		[HttpGet]
		public IActionResult NewCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult NewCategory(Category category) 
		{
			_categoryService.Add(category);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteCategory(int id) 
		{
			var category = _categoryService.GetById(id);
			category.Status = false;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult GetCategory(int id)
		{
			var category = _categoryService.GetById(id);
			return View(category);
		}
		[HttpPost]
		public IActionResult UpdateCategory(Category category)
		{
			_categoryService.Update(category);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

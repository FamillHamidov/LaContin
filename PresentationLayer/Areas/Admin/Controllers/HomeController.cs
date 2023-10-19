using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using FluentValidation.Results;
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
			var exist = true;
			var categories = _categoryService.GetAll();
			CategoryValidator validations = new CategoryValidator();
			ValidationResult result = validations.Validate(category);
			if (result.IsValid)
			{
				foreach (var item in categories.Where(x => x.Status == true))
				{

					if (category.Name.ToUpper() == item.Name.ToUpper())
					{
						exist = false;
					}
				}
				if (exist == false)
				{
					ModelState.AddModelError("", "Daxil etdiyiniz ad artıq mövcuddur");
				}
				else
				{
					_categoryService.Add(category);
					_context.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
			}
			return View();
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
		//public bool CheckName(string name)
		//{
		//	var exist = true;
		//	var categories = _categoryService.GetAll();
		//	Category category = new Category();
		//	CategoryValidator validations = new CategoryValidator();
		//	ValidationResult result = validations.Validate(category);
		//	if (result.IsValid)
		//	{
		//		foreach (var item in categories.Where(x => x.Status == true))
		//		{

		//			if (category.Name.ToUpper() == item.Name.ToUpper())
		//			{
		//				exist = false;
		//			}
		//		}
		//		if (exist == false)
		//		{
		//			ModelState.AddModelError("", "Daxil etdiyiniz ad artıq mövcuddur");
		//		}
		//		else
		//		{
		//			return true;
		//		}
		//	}
		//	else
		//	{
		//		foreach (var error in result.Errors)
		//		{
		//			ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
		//		}
		//	}
		//	return exist;
		//}
	}
}

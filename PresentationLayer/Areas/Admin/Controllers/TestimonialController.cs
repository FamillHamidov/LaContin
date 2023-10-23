using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TestimonialController : Controller
	{
		private readonly ITestimonialService _testimonialService;
		private readonly Context _context;

		public TestimonialController(ITestimonialService testimonialService, Context context)
		{
			_testimonialService = testimonialService;
			_context = context;
		}

		public IActionResult Index()
		{
			var testimonial = _testimonialService.GetAll();
			return View(testimonial);
		}
		[HttpGet]
		public IActionResult AddTestimonial()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddTestimonial(Testimonial testimonial)
		{
			TestimonialValidator validations = new TestimonialValidator();
			ValidationResult result = validations.Validate(testimonial);
			if (result.IsValid)
			{
				_testimonialService.Add(testimonial);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public IActionResult RemoveTestimonial(int id)
		{
			var testimonial = _testimonialService.GetById(id);
			_testimonialService.Delete(testimonial);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult GetTesttimonial(int id)
		{
			var testimonial = _testimonialService.GetById(id);
			return View(testimonial);
		}
		public IActionResult UpdateTestimonial(Testimonial testimonial)
		{
			TestimonialValidator validations = new TestimonialValidator();
			ValidationResult result = validations.Validate(testimonial);
			if (result.IsValid)
			{
				_testimonialService.Update(testimonial);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}

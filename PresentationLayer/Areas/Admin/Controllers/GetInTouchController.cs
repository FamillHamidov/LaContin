using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GetInTouchController : Controller
	{
		private readonly IGetInTouchService _getInTouchService;
		private readonly Context _context;

		public GetInTouchController(IGetInTouchService getInTouchService, Context context)
		{
			_getInTouchService = getInTouchService;
			_context = context;
		}
		public IActionResult Index()
		{
			var connect = _getInTouchService.GetAll();
			return View(connect);
		}
		[HttpGet]
		public IActionResult NewGetInTouch()
		{
			return View();
		}
		[HttpPost]
		public IActionResult NewGetInTouch(GetInTouch touch)
		{
			_getInTouchService.Add(touch);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteGetInTouch(int id)
		{
			var connect=_getInTouchService.GetById(id);
			_getInTouchService.Delete(connect);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult GetGetInTouch(int id)
		{
			var connect = _getInTouchService.GetById(id);
			return View(connect);
		}
		public IActionResult UpdategetInTouch(GetInTouch touch)
		{
			_getInTouchService.Update(touch);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

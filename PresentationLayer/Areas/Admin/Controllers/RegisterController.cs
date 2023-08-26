using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RegisterController : Controller
	{
		private readonly IAdminService _adminService;
		private readonly Context _context;

		public RegisterController(IAdminService adminService, Context context)
		{
			_adminService = adminService;
			_context = context;
		}
		[HttpGet]
		public IActionResult Index()

		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Login login)
		{
			_adminService.Add(login);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

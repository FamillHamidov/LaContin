using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly Context _context;
		private readonly UserManager<AdminUser> _userManager;
        public RegisterController(IAdminService adminService, Context context, UserManager<AdminUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
		public IActionResult Index()

		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(AdminRegisterViewModel model)
		{
			var admin = new AdminUser()
			{
				Name = model.Name,
				Surname=model.Surname,
				UserName = model.Username,
				Email = model.Mail
			};
			var result = await _userManager.CreateAsync(admin, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
			return View();
		}
	}
}

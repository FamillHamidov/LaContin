using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AdminUser> _signInManager;
        public LoginController(IAdminService adminService, SignInManager<AdminUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminLoginViewModel model)
        {
            var admin = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
            if (admin.Succeeded)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır!");
            }
            return View();

        }
    }
}

using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;

        public LoginController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login login)
        {
            var admin = _adminService.GetAll();
            var result = admin.FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);
            if (result != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Istifadeci adi ve ya sifre sehvdir");
            }
            return View();
        }
    }
}

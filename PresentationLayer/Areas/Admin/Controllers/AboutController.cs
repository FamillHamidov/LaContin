using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly Context _context;

        public AboutController(IAboutService aboutService, Context context)
        {
            _aboutService = aboutService;
            _context = context;
        }

        public IActionResult Index()
        {
            var about = _aboutService.GetAll();
            return View(about);
        }
        [HttpGet]
        public IActionResult NewAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewAbout(About about)
        {
            _aboutService.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAbout(int id)
        {
            var about = _aboutService.GetById(id);
            _aboutService.Delete(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetAbout(int id)
        {
            var about = _aboutService.GetById(id);
            return View(about);
        }
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

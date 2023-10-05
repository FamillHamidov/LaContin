using AutoMapper;
using DataAccessLayer.Concrete;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TitleSliderController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TitleSliderController(Context context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var images=_context.TitleSliders.ToList();
            return View(images);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(TitleSliderDto dto)
        {
            if (dto.Picture != null)
            {
                string folder = "title/Image/";
                folder += Guid.NewGuid().ToString() + "_" + dto.Picture.FileName;
                dto.ImageUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await dto.Picture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            var title = new TitleSlider()
            {
                ImageUrl = dto.ImageUrl,
            };
            _context.TitleSliders.Add(title);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RemoveImage(int id)
        {
            var image = _context.TitleSliders.Find(id);
            _context.TitleSliders.Remove(image);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using AutoMapper;
using DataAccessLayer.Concrete;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogoController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LogoController(Context context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var logo = _context.Logos.ToList();
            return View(logo);
        }
        [HttpGet]
        public IActionResult AddLogo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddLogo(LogoDto dto)
        {
            if (dto.Picture != null)
            {
                string folder = "logo/Image/";
                folder += Guid.NewGuid().ToString() + "_" + dto.Picture.FileName;
                dto.PictureUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await dto.Picture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            var logo = new Logo()
            {
                ImageUrl = dto.PictureUrl,
            };
            _context.Logos.Add(logo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetLogo(int id)
        {
            var logo = _context.Logos.Find(id);
            LogoDto dto = _mapper.Map<LogoDto>(logo);
            return View(dto);
        }
        public async Task<IActionResult> UpdateLogo(LogoDto dto, Logo logo)
        {
            if (dto.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(dto.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/logo/Image/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.Picture.CopyToAsync(stream);
                dto.PictureUrl = "/logo/Image/" + imageName;
            }
            else
            {
                dto.PictureUrl = logo.ImageUrl;
            }
            var updLogo = _mapper.Map<Logo>(dto);
            _context.Logos.Update(updLogo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

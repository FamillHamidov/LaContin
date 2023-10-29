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
    public class BannerController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public BannerController(Context context, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var banners=_context.BannerPictures.ToList();
            return View(banners);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(BannerPictureDto dto)
        {
            if (dto.Picture != null)
            {
                string folder = "banner/Image/";
                folder += Guid.NewGuid().ToString() + "_" + dto.Picture.FileName;
                dto.PictureUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await dto.Picture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            var banner = new BannerPicture()
            {
                PictureUrl = dto.PictureUrl,
               
            };
            _context.BannerPictures.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetBanner(int id)
        {
            var banner = _context.BannerPictures.Find(id);
            BannerPictureDto dto = _mapper.Map<BannerPictureDto>(banner);
            return View(dto);
        }
        public async Task<IActionResult> UpdateBanner(BannerPicture banner, BannerPictureDto dto)
        {
            if (dto.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(dto.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/banner/Image/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.Picture.CopyToAsync(stream);
                dto.PictureUrl = "/banner/Image/" + imageName;
            }
            else
            {
                dto.PictureUrl = banner.PictureUrl;
            }

            var updbanner = _mapper.Map<BannerPicture>(dto);
            _context.BannerPictures.Update(updbanner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

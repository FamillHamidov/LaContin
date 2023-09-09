using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, Context context, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _productService = productService;
            _context = context;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }
        [HttpGet]
        public IActionResult NewProduct()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll().Where(x => x.Status == true)
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();

            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductDto dto)
        {
            if (dto.Picture!=null)
            {
                string folder = "product/Image/";
                folder += Guid.NewGuid().ToString() + "_" + dto.Picture.FileName;
                dto.PictureUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await dto.Picture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            var newProduct = new Product()
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                NewPrice = dto.NewPrice,
                OldPrice = dto.OldPrice,
                Description = dto.Description,
                PictureUrl=dto.PictureUrl
            };
            _productService.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetById(id);
            _productService.Delete(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetById(id);
            List<SelectListItem> categories = (from x in _categoryService.GetAll().Where(x => x.Status == true)
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            ProductDto dto = _mapper.Map<ProductDto>(product);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductDto dto, Product product)
        {
            if (dto.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(dto.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/product/Image/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.Picture.CopyToAsync(stream);
                dto.PictureUrl = "/product/Image/" + imageName;
            }
            else
            {
                dto.PictureUrl = product.PictureUrl;
            }
            var updPrdct = _mapper.Map<Product>(dto);
            _productService.Update(updPrdct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult Image(int id)
        //{
        //    var product = _productService.GetById(id);
        //    ProductDto dto=_mapper.Map<ProductDto>(product);
        //    return View(dto);
        //}
        //[HttpPost]
        //public async Task<IActionResult> UploadImage1(ProductDto dto, Product product)
        //{
        //    if (dto.Picture!=null)
        //    {
        //        var resource = Directory.GetCurrentDirectory();
        //        var extension = Path.GetExtension(dto.Picture.FileName);
        //        var imageName = Guid.NewGuid() + extension;
        //        var saveLocation = resource + "/wwwroot/product/Image/" + imageName;
        //        var stream = new FileStream(saveLocation, FileMode.Create);
        //        await dto.Picture.CopyToAsync(stream);
        //        dto.PictureUrl = "/product/Image/" + imageName;
        //    }
        //    var updPrdct = _mapper.Map<Product>(dto);
        //    _productService.Update(updPrdct);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}

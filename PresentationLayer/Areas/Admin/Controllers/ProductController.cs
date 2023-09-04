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

        public ProductController(IProductService productService, Context context, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _context = context;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
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
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {

            _productService.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Image(int id)
        {
            var product = _productService.GetById(id);
            
            var updateProduct=new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Categories=_categoryService.GetAll(),
                NewPrice = product.NewPrice,
                OldPrice = product.OldPrice,
                Description = product.Description,
            };
            return View(updateProduct);
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage1(ProductDto dto, Product product)
        {
            if (dto.Picture!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(dto.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/productImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.Picture.CopyToAsync(stream);
                product.PictureUrl = "/productImage/" + imageName;
            }
            product.Name = dto.Name;
            product.NewPrice = dto.NewPrice;
            product.OldPrice = dto.OldPrice;
            product.Description = dto.Description;
            product.CategoryId = dto.CategoryId;
            _productService.Update(product);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult GetProductDto(int id)
        {
            var product = _productService.GetById(id);
            var category = _categoryService.GetAll();
			List<SelectListItem> categories = (from x in _categoryService.GetAll().Where(x => x.Status == true)
											   select new SelectListItem
											   {
												   Text = x.Name,
												   Value = x.Id.ToString()
											   }).ToList();
			ViewBag.categories = categories;
            ProductDto dto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
               
                NewPrice = product.NewPrice,
                OldPrice = product.OldPrice,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
            };
            return View(dto);
        }
    }
}

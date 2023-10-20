using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using FluentValidation.Results;
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
			if (dto.Picture != null)
			{
				string folder = "product/Image/";
				folder += Guid.NewGuid().ToString() + "_" + dto.Picture.FileName;
				dto.PictureUrl = "/" + folder;
				string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
				await dto.Picture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
			}
			if (dto.Picture1 != null)
			{
				string folder = "product/Image/";
				folder += Guid.NewGuid().ToString() + "_" + dto.Picture1.FileName;
				dto.PictureUrl1 = "/" + folder;
				string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
				await dto.Picture1.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
			}
			if (dto.Picture2 != null)
			{
				string folder = "product/Image/";
				folder += Guid.NewGuid().ToString() + "_" + dto.Picture2.FileName;
				dto.PictureUrl2 = "/" + folder;
				string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
				await dto.Picture2.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
			}
			var newProduct = new Product()
			{
				Name = dto.Name,
				CategoryId = dto.CategoryId,
				NewPrice = dto.NewPrice,
				OldPrice = dto.OldPrice,
				Description = dto.Description,
				PictureUrl = dto.PictureUrl,
				PictureUrl1 = dto.PictureUrl1,
				PictureUrl2 = dto.PictureUrl2
			};
			ProductValidator validations = new ProductValidator();
			ValidationResult result = validations.Validate(newProduct);
			if (result.IsValid)
			{
				_productService.Add(newProduct);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
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
			ProductValidator validations = new ProductValidator();
			ValidationResult result = validations.Validate(product);
			if (result.IsValid)
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
				if (dto.Picture1 != null)
				{
					var resource = Directory.GetCurrentDirectory();
					var extension = Path.GetExtension(dto.Picture1.FileName);
					var imageName = Guid.NewGuid() + extension;
					var saveLocation = resource + "/wwwroot/product/Image/" + imageName;
					var stream = new FileStream(saveLocation, FileMode.Create);
					await dto.Picture1.CopyToAsync(stream);
					dto.PictureUrl1 = "/product/Image/" + imageName;
				}
				else
				{
					dto.PictureUrl1 = product.PictureUrl1;
				}
				if (dto.Picture2 != null)
				{
					var resource = Directory.GetCurrentDirectory();
					var extension = Path.GetExtension(dto.Picture2.FileName);
					var imageName = Guid.NewGuid() + extension;
					var saveLocation = resource + "/wwwroot/product/Image/" + imageName;
					var stream = new FileStream(saveLocation, FileMode.Create);
					await dto.Picture2.CopyToAsync(stream);
					dto.PictureUrl2 = "/product/Image/" + imageName;
				}
				else
				{
					dto.PictureUrl2 = product.PictureUrl2;
				}

				var updPrdct = _mapper.Map<Product>(dto);
				_productService.Update(updPrdct);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
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

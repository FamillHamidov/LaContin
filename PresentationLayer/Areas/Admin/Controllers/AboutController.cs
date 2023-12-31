﻿using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, Context context, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _aboutService = aboutService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var about = _aboutService.GetAll();
            return View(about);
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
            AboutDto dto=_mapper.Map<AboutDto>(about);
            return View(dto);
        }
        public async Task<IActionResult> UpdateAbout(About about, AboutDto dto)
        {
            if (dto.Picture != null)
            {
                string folder = "about/Image/";
                folder += Guid.NewGuid().ToString() + "_" + dto.Picture.FileName;
                dto.PictureUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await dto.Picture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            else
            {
                dto.PictureUrl = about.ImageUrl;
            }
            var updAbout = new About()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.PictureUrl
            };
            _aboutService.Update(updAbout);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		private readonly Context _context;

		public ContactController(IContactService contactService, Context context)
		{
			_contactService = contactService;
			_context = context;
		}

		public IActionResult Index()
		{
			var contactInfo = _contactService.GetAll();
			return View(contactInfo);
		}
		[HttpGet]
		public IActionResult AddContact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddContact(Contact contact)
		{
			_contactService.Add(contact);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteContact(int id)
		{
			var contact = _contactService.GetById(id);
			_contactService.Delete(contact);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult GetContact(int id)
		{
			var contact=_contactService.GetById(id);
			return View(contact);
		}
		public IActionResult UpdateContact(Contact contact)
		{
			_contactService.Update(contact);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

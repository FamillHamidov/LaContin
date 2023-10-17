using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
        {
            var contactInfo = _contactService.GetAll();
            return View(contactInfo);
        }
    }
}

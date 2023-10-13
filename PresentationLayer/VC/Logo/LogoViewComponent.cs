using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.Logo
{
	public class LogoViewComponent : ViewComponent
	{
		private readonly Context _context;
		public LogoViewComponent(Context context)
		{
			_context = context;
		}

		public Task<IViewComponentResult> InvokeAsync()
		{
			var logoPic = _context.Logos.ToList();
			return Task.FromResult<IViewComponentResult>(View(logoPic));
		}
	}
}

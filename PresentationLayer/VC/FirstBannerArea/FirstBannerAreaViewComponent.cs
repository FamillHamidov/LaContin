using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.FirstBannerArea
{
	public class FirstBannerAreaViewComponent:ViewComponent
	{
		private readonly Context _context;

        public FirstBannerAreaViewComponent(Context context)
        {
            _context = context;
        }

        public Task<IViewComponentResult> InvokeAsync()
		{
			var banners = _context.BannerPictures.ToList();
			return Task.FromResult<IViewComponentResult>(View(banners));
		}
	}
}

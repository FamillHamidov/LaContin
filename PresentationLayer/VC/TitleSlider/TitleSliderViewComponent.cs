using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.TitleSlider
{
	public class TitleSliderViewComponent:ViewComponent
	{
		private readonly Context _context;

        public TitleSliderViewComponent(Context context)
        {
            _context = context;
        }

        public Task<IViewComponentResult> InvokeAsync()
		{
			var images=_context.TitleSliders.ToList();
			return Task.FromResult<IViewComponentResult>(View(images));
		}
	}
}

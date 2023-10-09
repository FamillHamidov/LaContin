using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.Testimonial
{
    public class TestimonialViewComponent:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

		public TestimonialViewComponent(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}
		public Task<IViewComponentResult> InvokeAsync()
        {
            var testimonial = _testimonialService.GetAll();
            return Task.FromResult<IViewComponentResult>(View(testimonial));
        }
    }
}

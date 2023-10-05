using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.VC.Testimonial
{
    public class TestimonialViewComponent:ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}

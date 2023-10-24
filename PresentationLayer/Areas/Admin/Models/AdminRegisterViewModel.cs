namespace PresentationLayer.Areas.Admin.Models
{
    public class AdminRegisterViewModel
    {
        public string Name { get; set; } = null!;
        public string Surname{ get; set; } = null!;
        public string Username{ get; set; } = null!;
        public string Password{ get; set; } = null!;
        public string Mail{ get; set; } = null!;
    }
}

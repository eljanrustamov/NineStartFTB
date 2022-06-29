using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NineStart.ViewModels
{
    public class SliderVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string RedirectToUrl { get; set; }
        [Required]
        public string RedirectToUrlText { get; set; }
        [Required]
        public bool IsDeactivated { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}

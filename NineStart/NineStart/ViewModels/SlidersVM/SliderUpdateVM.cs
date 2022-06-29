using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NineStart.ViewModels
{
    public class SliderUpdateVM
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string RedirectToUrl { get; set; }
        public string RedirectToUrlText { get; set; }
        public bool IsDeactivated { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

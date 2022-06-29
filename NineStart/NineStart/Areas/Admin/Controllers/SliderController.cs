using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace NineStart.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {

            try
            {
                var data = (await _sliderService.GetAll()).FirstOrDefault();

                return View(data);
            }
            catch (System.Exception ex)
            {
                return Json(new {
                    status = 504,
                    message = ex.Message
                });
            }

        }


    }
}






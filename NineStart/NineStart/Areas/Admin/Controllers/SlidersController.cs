using Business.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using NineStart.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace NineStart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
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

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(SliderVM sliderVM)
        {
            try
            {
                Slider slider = new Slider()
                {
                    Title = sliderVM.Title,
                    Description = sliderVM.Description, 
                    RedirectToUrl = sliderVM.RedirectToUrl, 
                    RedirectToUrlText = sliderVM.RedirectToUrlText,
                    IsDeactivated = sliderVM.IsDeactivated
                };

                await _sliderService.Create(slider);

                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                return Json(new
                {
                    status = 504,
                    message = ex.Message
                });
            }
        }


    }
}






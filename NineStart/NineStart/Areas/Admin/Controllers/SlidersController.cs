using Business.Services;
using DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NineStart.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NineStart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _env;
        public SlidersController(ISliderService sliderService,
                                 IWebHostEnvironment env)
        {
            _sliderService = sliderService;
            _env = env;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderVM sliderVM)
        {
            if(!ModelState.IsValid)
            {
                return View(sliderVM);
            }

            try
            {

                //
                if (!sliderVM.ImageFile.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("ImageFile","You can only upload image file");
                    return View();
                }

                if(sliderVM.ImageFile.Length > (1024 * 1024) * 2)
                {
                    ModelState.AddModelError("ImageFile", "You cannot  upload more than 2 mb");
                    return View();
                }

                string fileName = sliderVM.ImageFile.FileName;

                if(fileName.Length > 64)
                {
                    fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/sliders", newFileName);

                using(FileStream stream = new FileStream(path, FileMode.Create))
                {
                    sliderVM.ImageFile.CopyTo(stream);
                }
                    //


                    Slider slider = new Slider()
                    {
                        Title = sliderVM.Title,
                        Description = sliderVM.Description,
                        RedirectToUrl = sliderVM.RedirectToUrl,
                        RedirectToUrlText = sliderVM.RedirectToUrlText,
                        IsDeactivated = sliderVM.IsDeactivated,
                        ImageName = newFileName
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

        public async Task<IActionResult> Update(int? id)
        {

            try
            {
                var data = await _sliderService.Get(id);

                SliderUpdateVM sliderVM = new SliderUpdateVM()
                {
                    Title = data.Title,
                    Description = data.Description,
                    RedirectToUrl = data.RedirectToUrl,
                    RedirectToUrlText = data.RedirectToUrlText,
                    IsDeactivated = data.IsDeactivated,
                };

                return View(sliderVM);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 504,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM sliderUpdateVM)
        {

            try
            {
                var dbSlider = await _sliderService.Get(id);

                if(sliderUpdateVM.ImageFile != null)
                {
                   if (!sliderUpdateVM.ImageFile.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("ImageFile","error 1");
                        return View();
                    }

                   if(sliderUpdateVM.ImageFile.Length > (1024*1024)*2) 
                    {
                        ModelState.AddModelError("ImageFile", "error 2");
                        return View();
                    }

                    string fileName = sliderUpdateVM.ImageFile.FileName;

                    if (fileName.Length > 64)
                    {
                        fileName.Substring(fileName.Length - 64, 64);
                    }

                    string newFileName = Guid.NewGuid().ToString() + fileName;

                    string path = Path.Combine(_env.WebRootPath, "uploads/sliders", newFileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        sliderUpdateVM.ImageFile.CopyTo(stream);
                    }
                    // db da varsa yeni yaratdigimizi add edir
                    dbSlider.ImageName = newFileName;
                }
                else
                {
                    // db da yoxdursa evvelki image name i goturur
                    dbSlider.ImageName = sliderUpdateVM.ImageName;
                }

                dbSlider.Title = sliderUpdateVM.Title;
                dbSlider.Description = sliderUpdateVM.Description;
                dbSlider.RedirectToUrl = sliderUpdateVM.RedirectToUrl;  
                dbSlider.RedirectToUrlText = sliderUpdateVM.RedirectToUrlText;
                dbSlider.IsDeactivated = sliderUpdateVM.IsDeactivated;


                await _sliderService.Update(dbSlider);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
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






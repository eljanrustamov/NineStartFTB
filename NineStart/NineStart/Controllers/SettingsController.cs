using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NineStart.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        //public async Task<IActionResult> IndexAsync()
        //{
        //    try
        //    {
        //        var datas = await _settingsService.GetAllAsync();
        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }

        //    return View(datas);
        //}
    }
}

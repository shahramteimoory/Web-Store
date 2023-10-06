using EndPoint.site.Models;
using EndPoint.site.Models.ViewModels.HomePage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommonFacad _commonFacad;

        public HomeController(ILogger<HomeController> logger, ICommonFacad commonFacad)
        {
            _logger = logger;
            _commonFacad = commonFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _commonFacad.getSliderService.Execute().Data
            };
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

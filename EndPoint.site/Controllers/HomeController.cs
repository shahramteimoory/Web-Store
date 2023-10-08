using EndPoint.site.Models;
using EndPoint.site.Models.ViewModels.HomePage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Products.FacadPattern;
using Web_Store.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommonFacad _commonFacad;
        private readonly IProductFacad _productFacad;
        private readonly IHomePageFacad _homePageFacad;
        public HomeController(
            ILogger<HomeController> logger, 
            ICommonFacad commonFacad, 
            IProductFacad productFacad, 
            IHomePageFacad homePageFacad)
        {
            _logger = logger;
            _commonFacad = commonFacad;
            _productFacad = productFacad;
            _homePageFacad = homePageFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _commonFacad.getSliderService.Execute().Data,
                PageImages = _commonFacad.getHomePageImageService.Execute().Data,
                ProductsForSite1 = _productFacad.getProductForSiteService.Execute(Ordering.MostVisited, null, 1, 6, 1).Data.products,
                CategoryHomePageDto = _homePageFacad.productCategoryHomePageService.Execute()
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.HomePage.Commands.AddHomePageImages;
using Web_Store.Application.Services.HomePage.FacadPattern;
using Web_Store.Domain.Entites.HomePage;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IHomePageFacad _homePageFacad;
        public HomePageImagesController(IHomePageFacad homePageFacad)
        {
            _homePageFacad = homePageFacad;
        }

        public IActionResult Index()
        {
            return View(_homePageFacad.igetImageSiteService.Execute().Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile File, string Link, ImageLocation imageLocation)
        {
            if (File == null || Link == null)
            {
                var result = new Web_Store.Common.Dto.ResultDto()
                {
                    IsSuccess = false,
                    Message = "اطلاعات درخواستی به درستی وارد نشده"
                };
                return Json(result);

            }
            else
            {
                var result = _homePageFacad.AddHomePageImagesService.Execute(new RequestAddHomePageImagesDto
                {
                    File = File,
                    Link = Link,
                    imageLocation = imageLocation
                });
                return Json(result);
            }
        }
        [HttpPost]
        public IActionResult Delete(long imageId)
        {
            return Json(_homePageFacad.deleteHomeImages.Execute(imageId));
        }
     }
}

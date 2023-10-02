using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacad _ProductFacad;
        public ProductController(IProductFacad ProductFacad)
        {
            _ProductFacad=ProductFacad;
        }
        public IActionResult Index(int page=1)
        {
            return View(_ProductFacad.getProductForSiteService.Execute(page).Data);
        }
        public IActionResult Details(long Id)
        {
            return View(_ProductFacad.getProductDetailForSiteService.Execute(Id).Data);
        }
    }
}

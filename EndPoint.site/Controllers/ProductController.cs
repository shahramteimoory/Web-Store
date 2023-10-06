using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacad _ProductFacad;
        public ProductController(IProductFacad ProductFacad)
        {
            _ProductFacad=ProductFacad;
        }
        public IActionResult Index(Ordering ordering, string SearchKey, int page = 1,int PageSize=20 , long? CatId = null)
        {
            return View(_ProductFacad.getProductForSiteService.Execute(ordering, SearchKey,page, PageSize, CatId).Data);
        }
        public IActionResult Details(long Id)
        {
            return View(_ProductFacad.getProductDetailForSiteService.Execute(Id).Data);
        }
    }
}

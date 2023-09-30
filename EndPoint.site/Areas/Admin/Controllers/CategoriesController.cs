using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _ProductFacad;
        public CategoriesController(IProductFacad ProductFacad)
        {
            _ProductFacad=ProductFacad;
        }
        public IActionResult Index(long? parentId)
        {
            return View(_ProductFacad.GetCategoriesService.Execut(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? parentId,string Name)
        {
            var result=_ProductFacad.AddNewCategoryService.Execute(parentId, Name);
            return Json(result);
        }
    }
}

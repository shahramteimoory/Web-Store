using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Products.Commands.EditCategory;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
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
        [HttpPost]
        public IActionResult EditCategory(long categoryId , string Name)
        {
            return Json(_ProductFacad.editCategory.Execute(new RequestEditCategoryDto
            {
                 CategoryId = categoryId,
                 Name = Name
            }));
        }
        [HttpPost]
        public IActionResult Delete(long categoryId)
        {
            return Json(_ProductFacad.removeCategory.Execute(categoryId));
        }
    }
}

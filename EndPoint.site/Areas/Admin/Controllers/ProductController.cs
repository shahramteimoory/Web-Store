using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Products.Commands.AddNewProduct;
using Web_Store.Application.Services.Products.FluentValidation;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Products;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _ProductFacad;
        public ProductController(IProductFacad ProductFacad)
        {
            _ProductFacad = ProductFacad;
        }
        public IActionResult Index(int Page=1,int PageSize=20)
        {
            return View(_ProductFacad.getProductForAdminService.Execute(Page, PageSize).Data);
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.categories = new SelectList(_ProductFacad.GetAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request, List<AddNewProduct_Features> Features)
        {
            var product = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Description = request.Description,
                Price = request.Price,
                Inventory = request.Inventory,
                CategoryId = request.CategoryId,
                Display = request.Display,
            };
            var validator = new Validation();
            var validationResult = validator.Validate(product);
            if (validationResult.IsValid)
            {
                List<IFormFile> images = new List<IFormFile>();
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var file = Request.Form.Files[i];
                    images.Add(file);
                }
                request.Images = images;
                request.Features = Features;
                return Json(_ProductFacad.AddNewProductService.Execute(request));
            }
            else
            {
                var errorMessages = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));

                return Json(new ResultDto { IsSuccess = false, Message = errorMessages });

            }
        }
        [HttpGet]
        public IActionResult Detail(long Id)
        {
            return View(_ProductFacad.getProductDetailForAdminService.Execute(Id).Data);
        }
        [HttpPost]
        public IActionResult Remove(long Id)
        {
            return Json(_ProductFacad.removeProductService.Execute(Id));
        }
    }

}

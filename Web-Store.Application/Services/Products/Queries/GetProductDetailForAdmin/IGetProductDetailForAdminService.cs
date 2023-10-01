using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Products;

namespace Web_Store.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdminService
    {
        ResultDto<ProductDetailForAdminDto>Execute(long id); 
    }
    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForAdminService(IDataBaseContext context)
        {
            _context= context;
        }
        public ResultDto<ProductDetailForAdminDto> Execute(long id)
        {
            var product=_context.products
                .Include(p=>p.Category).ThenInclude(p=>p.ParentCategory)
                .Include(p=>p.ProductFeatures).Include(p=>p.ProductImages).Where(p=>p.Id == id).FirstOrDefault();
            return new ResultDto<ProductDetailForAdminDto>
            {
                Data = new ProductDetailForAdminDto()
                {
                    Brand = product.Brand,
                    Category = GetCategory(product.Category),
                    Description = product.Description,
                    Displayed = product.Display,
                    Id = product.Id,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto()
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImages.ToList().Select(p => new ProductDetailImageDto
                    {
                        Id = p.Id,
                        Src = p.Src,
                    }).ToList(),
                },
                IsSuccess = true,
                Message = ""
            };
        }
        private string GetCategory(Category category)
        {
            string result=category.ParentCategory !=null ? $"{category.ParentCategory.Name} -" :"";
            return result += category.Name;
        }
    }
}

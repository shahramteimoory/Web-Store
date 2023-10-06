using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetProductDetailForSite
{
    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForSiteService(IDataBaseContext context)
        {
            _context= context;
        }
        public ResultDto<ProductDetailForSiteDto> Execute(long Id)
        {
            var product = _context.products.Include(p=>p.Category)
                //vaghti include mizarim dige nemishe find gozasht bayad where bezarim
                .ThenInclude(p=>p.ParentCategory).Include(p=>p.ProductImages)
                .Include(p=>p.ProductFeatures).Where(p=>p.Id==Id).FirstOrDefault();
            if (product==null)
            {
                return new ResultDto<ProductDetailForSiteDto>()
                {
                    Data = new ProductDetailForSiteDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "محصول مورد نظر یافت نشد"
                };
            }
            product.ViewCount++;
            _context.SaveChanges();
            return new ResultDto<ProductDetailForSiteDto>()
            {
                Data = new ProductDetailForSiteDto
                {
                    Brand = product.Brand,
                    Category =$"{product.Category.ParentCategory.Name} - {product.Category.Name}",
                    Description = product.Description,
                    Id = Id,
                    price = product.Price,
                    Title=product.Name,
                    Images=product.ProductImages.Select(p=>p.Src).ToList(),
                    Features=product.ProductFeatures.Select(p=> new ProductDetailForSite_FeaturesDto
                    {
                        DisplayName=p.DisplayName,
                        Value=p.Value,
                    }).ToList(),
                },
                IsSuccess= true
            };
            
        }
    }
}

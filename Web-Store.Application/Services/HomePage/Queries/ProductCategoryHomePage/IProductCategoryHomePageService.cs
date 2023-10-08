using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Queries.ProductCategoryHomePage
{
    public interface IProductCategoryHomePageService
    {
        ResultDto<List<CategoryHomePageDto>> Execute();
    }
    public class ProductCategoryHomePageService : IProductCategoryHomePageService
    {
        private readonly IDataBaseContext _context;
        public ProductCategoryHomePageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoryHomePageDto>> Execute()
        {
            ResultDto<List<CategoryHomePageDto>> res = new ResultDto<List<CategoryHomePageDto>>();
            try
            {
                res.Data = _context.categories.Select(p => new CategoryHomePageDto { CategoryId = p.Id, CategoryName = p.Name }).ToList();

                foreach (var item in res.Data)
                {
                    item.Products = _context.products
                        .Take(5)
                        .Where(p => p.CategoryId == item.CategoryId)
                        .Select(p => new ProductcHomePageDto
                        {
                            Title = p.Name,
                            ProductId = p.Id,
                            Price = p.Price,
                            Src = p.ProductImages.Select(i => i.Src).FirstOrDefault()
                        }
                        ).ToList();
                }

                res.IsSuccess = true;
            }
            catch (Exception e)
            {
                res.IsSuccess = false;
                res.Message = e.Message;
            }
            
            return res;
        }
    }



    public class CategoryHomePageDto
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ProductcHomePageDto> Products { get; set; }

    }

    public class ProductcHomePageDto
    {
        public long ProductId { get; set; }
        public string Src { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}

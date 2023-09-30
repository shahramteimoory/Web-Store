using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetCategories
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetCategoriesService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<List<CategoriesDto>> Execut(long? parentId)
        {
            // بازیابی دسته‌ها با شامل کردن دسته والد، زیردسته‌ها و فیلتر بر اساس parentId
            var categories = _context.categories
                .Include(c => c.ParentCategory)
                .Include(c => c.SubCategories)
                .Where(c => c.ParentCategoryId == parentId)
                .ToList()
                .Select(c => new CategoriesDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Parent = c.ParentCategory != null ? new ParentCategoryDto
                    {
                        Id = c.ParentCategory.Id,
                        Name = c.ParentCategory.Name,
                    } : null,
                    HasChild = c.SubCategories.Count() > 0 ? true : false,
                })
                .ToList();

            // برگرداندن نتیجه به صورت ResultDto<List<CategoriesDto>>
            return new ResultDto<List<CategoriesDto>>
            {
                Data = categories,
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد."
            };
        }
    }
}

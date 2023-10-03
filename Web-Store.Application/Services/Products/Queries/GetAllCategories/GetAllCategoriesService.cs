using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetAllCategories
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetAllCategoriesService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<List<AllCategoriesDto>> Execute()
        {

            var categories = _context
                .categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                }
                ).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}

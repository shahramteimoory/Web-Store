using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuService : IGetMenuService
    {
        private readonly IDataBaseContext _context;
        public GetMenuService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<MenuItemDto>> Execute()
        {
            var category = _context.categories
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Child = p.SubCategories.ToList().Select(child => new MenuItemDto
                    {
                        CatId = child.Id,
                        Name = child.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<MenuItemDto>>()
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetCategory
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _context;
        public GetCategoryService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<List<GetCategoryDto>> Execute()
        {
            var category = _context.categories.Where(c => c.ParentCategoryId == null).ToList().Select(c=>new GetCategoryDto
            {
                CatId= c.Id,
                CategoryName= c.Name,
            }).ToList();
            return new ResultDto<List<GetCategoryDto>>()
            {
                Data = category,
                IsSuccess = true,

            };
     
        }
    }
}

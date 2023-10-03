using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Services.Products.Queries.GetCategories;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetCategory
{
    public interface IGetCategoryService
    {
        ResultDto<List<GetCategoryDto>> Execute();
    }
}

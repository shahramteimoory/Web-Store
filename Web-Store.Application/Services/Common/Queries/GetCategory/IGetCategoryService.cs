using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetCategory
{
    public interface IGetCategoryService
    {
        ResultDto<List<GetCategoryDto>> Execute();
    }
}

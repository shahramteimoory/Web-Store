using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        ResultDto<List<CategoriesDto>> Execut(long? parentId);
    }
}

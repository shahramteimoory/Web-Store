using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }
}

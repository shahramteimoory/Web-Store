using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Commands.RemoveCategory
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(long CategoriesId);
    }
}

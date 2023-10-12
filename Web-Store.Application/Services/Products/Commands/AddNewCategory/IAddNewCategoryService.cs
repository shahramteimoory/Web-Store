using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(long? ParentId, string Name);
    }
}

using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }
}

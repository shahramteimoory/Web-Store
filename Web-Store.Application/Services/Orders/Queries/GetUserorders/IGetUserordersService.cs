using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Orders.Queries.GetUserorders
{
    public interface IGetUserordersService
    {
        ResultDto<List<GetUserOrderDto>> Execute(long UserId);
    }
}

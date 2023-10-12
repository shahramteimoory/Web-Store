using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(int count, long ProductId, Guid BroserId);
        ResultDto RemoveFromCart(long ProductId, Guid BroserId);
        ResultDto<CartDto> GetMyCart(Guid BroserId, long? userId);
        ResultDto Add(long CartItemId);
        ResultDto LowOff(long CartItemId);
    }
}

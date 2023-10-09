using System;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(long ProductId, Guid BroserId);
        ResultDto RemoveFromCart(long ProductId, Guid BroserId);
        ResultDto<CartDto> GetMyCart (Guid BroserId);
    }
}

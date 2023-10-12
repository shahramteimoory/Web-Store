using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Commands.RemoveProduct
{
    public interface IRemoveProductService
    {
        ResultDto Execute(long productId);
    }
}

using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdminService
    {
        ResultDto<ProductDetailForAdminDto> Execute(long id);
    }
}

using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public interface IGetProductForAdminService
    {
        ResultDto<ProductForAdminDto> Execute(int page = 1, int pagesize = 20);
    }
}

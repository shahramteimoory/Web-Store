using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Queries.GetAllImageSite
{
    public interface IGetImageSiteService
    {
        ResultDto<List<GetImageSiteDto>> Execute();
    }
}

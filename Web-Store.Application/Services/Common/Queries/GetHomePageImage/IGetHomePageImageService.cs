using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetHomePageImage
{
    public interface IGetHomePageImageService
    {
        ResultDto<List<HomePageImageDto>> Execute();
    }
}

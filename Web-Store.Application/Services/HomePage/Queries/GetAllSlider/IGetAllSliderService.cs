using Web_Store.Application.Services.Common.Queries.GetSlider;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Queries.GetAllSlider
{
    public interface IGetAllSliderService
    {
        ResultDto<List<SliderDto>> Execute();
    }
}


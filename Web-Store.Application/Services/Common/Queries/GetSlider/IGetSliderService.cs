using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();
    }
}

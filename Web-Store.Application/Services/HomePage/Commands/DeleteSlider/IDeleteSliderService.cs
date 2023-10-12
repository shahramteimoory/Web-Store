using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Commands.DeleteSlider
{
    public interface IDeleteSliderService
    {
        ResultDto Execute(long SliderId);
    }
}

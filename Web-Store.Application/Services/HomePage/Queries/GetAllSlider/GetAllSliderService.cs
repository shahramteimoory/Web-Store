using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Services.Common.Queries.GetSlider;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Queries.GetAllSlider
{
    public class GetAllSliderService : IGetAllSliderService
    {
        private readonly IDataBaseContext _context;
        public GetAllSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var slider = _context.sliders.ToList().Select(c => new SliderDto
            {
                Link = c.Link,
                Name = c.Name,
                Src = c.Src,
                Id = c.Id,
            }).ToList();
            return new ResultDto<List<SliderDto>>
            {
                Data = slider,
                IsSuccess = true
            };
        }
    }
}


using System.Collections.Generic;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetSlider
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSliderService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var slider = _context.sliders.OrderByDescending(s => s.Id).ToList()
                .Select(s => new SliderDto
            {
                    Name = s.Name,
                    Link = s.Link,
                    Src = s.Src,
            }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = slider,
                IsSuccess = true
            };
        }
    }
}

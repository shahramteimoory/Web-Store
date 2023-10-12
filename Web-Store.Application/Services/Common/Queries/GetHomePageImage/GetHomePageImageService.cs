using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetHomePageImage
{
    public class GetHomePageImageService : IGetHomePageImageService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImageDto>> Execute()
        {
            var images = _context.HomePageImages.OrderByDescending(x => x.Id)
                .Select(x => new HomePageImageDto
                {
                    imageLocation = x.imageLocation,
                    Id = x.Id,
                    Link = x.Link,
                    Src = x.Src,

                }).ToList();
            return new ResultDto<List<HomePageImageDto>>()
            {
                Data = images,
                IsSuccess = true
            };
        }
    }
}

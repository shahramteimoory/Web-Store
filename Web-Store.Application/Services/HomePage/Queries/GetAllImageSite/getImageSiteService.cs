using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Queries.GetAllImageSite
{
    public class getImageSiteService : IGetImageSiteService
    {
        private readonly IDataBaseContext _context;
        public getImageSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetImageSiteDto>> Execute()
        {
            var images = _context.HomePageImages.ToList().Select(I => new GetImageSiteDto
            {
                Id = I.Id,
                Link = I.Link,
                Src = I.Src,
                imageLocation = I.imageLocation
            }).ToList();
            return new ResultDto<List<GetImageSiteDto>>()
            {
                Data = images,
                IsSuccess = true

            };
        }
    }
}

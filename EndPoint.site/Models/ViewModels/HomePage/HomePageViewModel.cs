using Web_Store.Application.Services.Common.Queries.GetHomePageImage;
using Web_Store.Application.Services.Common.Queries.GetSlider;
using Web_Store.Application.Services.HomePage.Queries.ProductCategoryHomePage;
using Web_Store.Application.Services.Products.Queries.GetProductForSite;
using Web_Store.Common.Dto;

namespace EndPoint.site.Models.ViewModels.HomePage
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImageDto> PageImages { get; set; }
        public List<ProductForSiteDto> ProductsForSite1 { get; set; }
        public ResultDto<List<CategoryHomePageDto>> CategoryHomePageDto { get; set; }
    }
}

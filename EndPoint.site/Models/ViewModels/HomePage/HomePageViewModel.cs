using System.Collections.Generic;
using Web_Store.Application.Services.Common.Queries.GetHomePageImage;
using Web_Store.Application.Services.Common.Queries.GetSlider;
using Web_Store.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.site.Models.ViewModels.HomePage
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImageDto> PageImages {  get; set; }  
        public List<ProductForSiteDto> ProductsForSite1 { get; set; }
    }
}

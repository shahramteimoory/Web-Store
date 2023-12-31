﻿using Web_Store.Application.Services.HomePage.Commands.AddHomePageImages;
using Web_Store.Application.Services.HomePage.Commands.AddNewSlider;
using Web_Store.Application.Services.HomePage.Commands.DeleteImagesSite;
using Web_Store.Application.Services.HomePage.Commands.DeleteSlider;
using Web_Store.Application.Services.HomePage.Queries.GetAllImageSite;
using Web_Store.Application.Services.HomePage.Queries.GetAllSlider;
using Web_Store.Application.Services.HomePage.Queries.ProductCategoryHomePage;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface IHomePageFacad
    {
        IAddNewSliderService AddNewSliderService { get; }
        IGetAllSliderService getAllSliderService { get; }
        IDeleteSliderService deleteSliderService { get; }
        IAddHomePageImagesService AddHomePageImagesService { get; }
        IGetImageSiteService igetImageSiteService { get; }
        IDeleteHomeImagesService deleteHomeImages { get; }
        IProductCategoryHomePageService productCategoryHomePageService { get; }
    }
}

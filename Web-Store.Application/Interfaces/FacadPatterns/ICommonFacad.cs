﻿using Web_Store.Application.Services.Common.Queries.GetCategory;
using Web_Store.Application.Services.Common.Queries.GetHomePageImage;
using Web_Store.Application.Services.Common.Queries.GetMenuItem;
using Web_Store.Application.Services.Common.Queries.GetSlider;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface ICommonFacad
    {
        IGetMenuService getMenuService { get; }
        IGetCategoryService getCategoryService { get; }
        IGetSliderService getSliderService { get; }
        IGetHomePageImageService getHomePageImageService { get; }
    }
}

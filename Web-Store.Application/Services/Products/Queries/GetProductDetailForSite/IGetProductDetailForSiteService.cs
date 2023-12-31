﻿using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetProductDetailForSite
{
    public interface IGetProductDetailForSiteService
    {
        ResultDto<ProductDetailForSiteDto> Execute(long id);
    }
}

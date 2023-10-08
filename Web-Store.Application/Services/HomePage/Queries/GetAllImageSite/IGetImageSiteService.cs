using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Queries.GetAllImageSite
{
    public interface IGetImageSiteService
    {
        ResultDto<List<GetImageSiteDto>> Execute();
    }
}

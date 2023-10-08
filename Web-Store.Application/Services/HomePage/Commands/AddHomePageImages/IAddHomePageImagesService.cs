﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Commands.AddHomePageImages
{
    public interface IAddHomePageImagesService
    {
        ResultDto Execute(RequestAddHomePageImagesDto request);
    }
}

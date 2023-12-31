﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Common.Dto;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SlidersController : Controller
    {
        private readonly IHomePageFacad _homePageFacad;
        public SlidersController(IHomePageFacad homePageFacad)
        {
            _homePageFacad = homePageFacad;
        }
        public IActionResult Index()
        {

            return View(_homePageFacad.getAllSliderService.Execute().Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile File, string Link, string Name)
        {

            if (File is null)
            {
                var res = new ResultDto()
                {
                    IsSuccess = false,
                    Message = "لطفا اطلاعات را وارد کنید"
                };
                return Json(res);
            }
            var result = _homePageFacad.AddNewSliderService.Execute(File, Link, Name);
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(long SliderId)
        {
            return Json(_homePageFacad.deleteSliderService.Execute(SliderId));
        }
    }
}

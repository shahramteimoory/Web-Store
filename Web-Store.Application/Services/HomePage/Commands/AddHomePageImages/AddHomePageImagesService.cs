using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Services.Products.Commands.AddNewProduct;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.HomePage;

namespace Web_Store.Application.Services.HomePage.Commands.AddHomePageImages
{
    public class AddHomePageImagesService : IAddHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddHomePageImagesService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context=context;
            _environment = environment;
        }
        public ResultDto Execute(RequestAddHomePageImagesDto request)
        {
            if (request==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message="خطا عملیات مورد نظر انجام نشد"
                };
            }
            var resultUpload = UploadFile(request.File);

            HomePageImages homePageImages = new HomePageImages()
            {
                Link = request.Link,
                Src = resultUpload.FileNameAddress,
                imageLocation=request.imageLocation
            };
            _context.HomePageImages.Add(homePageImages);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message="تصویر مورد نظر با موفقیت اضافه شد"
            };
        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePgae\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
}

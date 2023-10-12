using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Services.Products.Commands.AddNewProduct;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.HomePage;

namespace Web_Store.Application.Services.HomePage.Commands.AddNewSlider
{
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewSliderService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(IFormFile file, string Link, string Name)
        {
            try
            {
                if (file == null && Link == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "لطفا یک عکس برای اسلایدر آپلود کنید"
                    };
                }
                var ResulyUpload = UploadFile(file);
                Slider slider = new Slider
                {
                    Link = Link,
                    Src = ResulyUpload.FileNameAddress,
                    Name = Name

                };
                _context.sliders.Add(slider);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "اسلایدر اضافه شد"
                };

            }
            catch
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا . عملیات  انجام نشد"

                };
            }

        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePgae\Slider\";
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

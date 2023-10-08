using System;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Commands.DeleteImagesSite
{
    public class DeleteHomeImagesService : IDeleteHomeImagesService
    {
        private readonly IDataBaseContext _context;
        public DeleteHomeImagesService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto Execute(long imageId)
        {
            try
            {
                var image = _context.HomePageImages.Find(imageId);
                if (image == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message="تصویر مورد نظر پیدا نشد"
                    };
                }
                image.IsRemoved = true;
                image.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "تصویر با موفقیت حذف شد"
                };
            }
            catch 
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "خطا عملیات انجام نشد"
                };
                
            }

        }
    }
}

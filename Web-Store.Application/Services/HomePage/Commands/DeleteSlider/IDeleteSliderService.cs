using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Commands.DeleteSlider
{
    public interface IDeleteSliderService
    {
        ResultDto Execute(long SliderId);
    }
    public class DeleteSliderService : IDeleteSliderService
    {
        private readonly IDataBaseContext _context;
        public DeleteSliderService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto Execute(long SliderId)
        {
            try
            {
                var slider = _context.sliders.Find(SliderId);
                slider.RemoveTime = DateTime.Now;
                slider.IsRemoved = true;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "اسلایدر با موقیت حذف شد"
                };
            }
            catch 
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "خطا مشکلی در حذف اسلایدر رخ داده"
                };
                
            }
 
        }
    }
}

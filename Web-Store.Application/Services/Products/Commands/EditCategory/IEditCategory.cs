using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Commands.EditCategory
{
    public interface IEditCategory
    {
        public ResultDto Execute(RequestEditCategoryDto request);
    }

    public class EditCategory : IEditCategory
    {
        private readonly IDataBaseContext _context;
        public EditCategory(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditCategoryDto request)
        {
            try
            {
                var category = _context.categories.Find(request.CategoryId);
                if (category == null)
                {
                    new ResultDto
                    {
                        IsSuccess = false,
                        Message = "دسته بندی مورد نظر یافت نشد",
                    };
                }
                category.Name = request.Name;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "دسته بندی مورد نظر تغییر کرد"
                };
            }
            catch
            {

                return new ResultDto { IsSuccess = false, Message = "خطایی در تغییر دسته بندی رخ داده" };
            }
        }
    }
}

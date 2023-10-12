using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Commands.RemoveCategory
{
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _context;
        public RemoveCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long CategoriesId)
        {
            try
            {
                var category = _context.categories.Find(CategoriesId);
                if (category == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "دسته بندی یافت نشد"
                    };
                }
                category.RemoveTime = DateTime.Now;
                category.IsRemoved = true;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "دسته بندی با موفقیت حذف شد"
                };
            }
            catch
            {
                return new ResultDto() { IsSuccess = false, Message = "خطایی در حذف دسته بندی رخ داده" };

            }

        }
    }
}

using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Products;

namespace Web_Store.Application.Services.Products.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long? ParentId, string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام دسته بندی را وارد کنید"
                };
            }
            Category category = new Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId)
            };
            _context.categories.Add(category);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موقیت اضافه شد"

            };
        }

        private Category GetParent(long? ParentId)
        {
            return _context.categories.Find(ParentId);
        }
    }
}

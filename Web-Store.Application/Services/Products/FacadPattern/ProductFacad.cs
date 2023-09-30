using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Products.Commands.AddNewCategory;
using Web_Store.Application.Services.Products.Commands.EditCategory;
using Web_Store.Application.Services.Products.Commands.RemoveCategory;
using Web_Store.Application.Services.Products.Queries.GetCategories;

namespace Web_Store.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        //اول یه ایتجکت از دیتا بیس میکنیم
        private readonly IDataBaseContext _context;
        public ProductFacad(IDataBaseContext context)
        {
            _context=context;
        }
        //یه نمونه از سرویسی که میخوایم تو قساد بزاریمش  میسازیم 
        private AddNewCategoryService _AddNewCategoryService;
        public AddNewCategoryService AddNewCategoryService
        {
            //_AddNewCategoryService اینو میخوایم بدیم یه کسی که میخواد ازش استفاده کنه 
            //چک میکنیم اگه خالی بود  یه تمونه جدید از سرویس میسازیم 
            get
            {
                return _AddNewCategoryService = _AddNewCategoryService ?? new AddNewCategoryService(_context);
            }
        }
        private IGetCategoriesService _GetCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _GetCategoriesService= _GetCategoriesService ?? new GetCategoriesService(_context);
            }
        }

        private IEditCategory _editCategory;
        public IEditCategory editCategory
        {
            get
            {
                return _editCategory= _editCategory ?? new EditCategory(_context);
            }
        }
        private IRemoveCategoryService _RemoveCategoryService;
        public IRemoveCategoryService removeCategory
        {
            get
            {
                return _RemoveCategoryService= _RemoveCategoryService ?? new RemoveCategoryService(_context); 
            }
        }
    }
}

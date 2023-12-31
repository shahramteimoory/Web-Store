﻿using Microsoft.AspNetCore.Hosting;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Products.Commands.AddNewCategory;
using Web_Store.Application.Services.Products.Commands.AddNewProduct;
using Web_Store.Application.Services.Products.Commands.EditCategory;
using Web_Store.Application.Services.Products.Commands.RemoveCategory;
using Web_Store.Application.Services.Products.Commands.RemoveProduct;
using Web_Store.Application.Services.Products.FluentValidation;
using Web_Store.Application.Services.Products.Queries.GetAllCategories;
using Web_Store.Application.Services.Products.Queries.GetCategories;
using Web_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Web_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Web_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Web_Store.Application.Services.Products.Queries.GetProductForSite;

namespace Web_Store.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        //اول یه ایتجکت از دیتا بیس میکنیم
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
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
                return _GetCategoriesService = _GetCategoriesService ?? new GetCategoriesService(_context);
            }
        }

        private IEditCategory _editCategory;
        public IEditCategory editCategory
        {
            get
            {
                return _editCategory = _editCategory ?? new EditCategory(_context);
            }
        }
        private IRemoveCategoryService _RemoveCategoryService;
        public IRemoveCategoryService removeCategory
        {
            get
            {
                return _RemoveCategoryService = _RemoveCategoryService ?? new RemoveCategoryService(_context);
            }
        }
        private AddNewProductService _AddNewProductService;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _AddNewProductService = _AddNewProductService ?? new AddNewProductService(_context, _environment);
            }
        }
        private IGetAllCategoriesService _GetAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _GetAllCategoriesService = _GetAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }
        private Validation _Validation;
        public Validation validationRules
        {
            get
            {
                return _Validation = _Validation ?? new Validation();
            }
        }
        private IGetProductForAdminService _GetProductForAdminService;
        public IGetProductForAdminService getProductForAdminService
        {
            get
            {
                return _GetProductForAdminService = _GetProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }

        private IGetProductDetailForAdminService _getProductDetailForAdmin;
        public IGetProductDetailForAdminService getProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdmin = _getProductDetailForAdmin ?? new GetProductDetailForAdminService(_context);
            }
        }
        private IRemoveProductService _RemoveProductService;
        public IRemoveProductService removeProductService
        {
            get
            {
                return _RemoveProductService = _RemoveProductService ?? new RemoveProductService(_context);
            }
        }
        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService getProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }
        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService getProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }
    }
}

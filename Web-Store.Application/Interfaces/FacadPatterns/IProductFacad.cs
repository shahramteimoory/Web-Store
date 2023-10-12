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

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }

        IEditCategory editCategory { get; }
        IRemoveCategoryService removeCategory { get; }

        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }

        Validation validationRules { get; }
        /// <summary>
        /// دریافت لیست محصولات برای مدیر
        /// </summary>
        IGetProductForAdminService getProductForAdminService { get; }

        /// <summary>
        /// دریافت جزعیات محصولات برای مدیر
        /// </summary>
        IGetProductDetailForAdminService getProductDetailForAdminService { get; }

        IRemoveProductService removeProductService { get; }
        IGetProductForSiteService getProductForSiteService { get; }
        IGetProductDetailForSiteService getProductDetailForSiteService { get; }
    }
}

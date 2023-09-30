using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Services.Products.Commands.AddNewCategory;
using Web_Store.Application.Services.Products.Queries.GetCategories;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService {  get; }
        IGetCategoriesService GetCategoriesService { get; }
    }
}

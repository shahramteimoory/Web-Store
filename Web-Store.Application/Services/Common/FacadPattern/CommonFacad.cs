using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Common.Queries.GetCategory;
using Web_Store.Application.Services.Common.Queries.GetMenuItem;
using Web_Store.Application.Services.Common.Queries.GetSlider;

namespace Web_Store.Application.Services.Common.FacadPattern
{
    public class CommonFacad : ICommonFacad
    {
        private readonly IDataBaseContext _context;
        public CommonFacad(IDataBaseContext context)
        {
            _context=context;
        }
        private IGetMenuService _getMenuService;
        public IGetMenuService getMenuService
        {
            get
            {
                return _getMenuService = _getMenuService ?? new GetMenuService(_context);
            }
        }
        private IGetCategoryService _getCategoryService;
        public IGetCategoryService getCategoryService
        {
            get
            {
                return _getCategoryService= _getCategoryService??new GetCategoryService(_context);
            }
        }
        public IGetSliderService _getSliderService;
        public IGetSliderService getSliderService
        {
            get
            {
                return _getSliderService = _getSliderService ?? new GetSliderService(_context);
            }
        }
    }
}

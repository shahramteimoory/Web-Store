using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Common.Queries.GetMenuItem;

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
    }
}

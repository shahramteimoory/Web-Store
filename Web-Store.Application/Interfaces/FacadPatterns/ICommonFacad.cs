using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Services.Common.Queries.GetMenuItem;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface ICommonFacad
    {
        IGetMenuService getMenuService {  get; }
    }
}

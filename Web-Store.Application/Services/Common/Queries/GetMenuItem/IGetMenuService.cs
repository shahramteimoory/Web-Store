using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }
}

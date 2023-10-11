using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Orders.Queries.GetUserorders
{
    public interface IGetUserordersService
    {
        ResultDto <List<GetUserOrderDto>> Execute(long UserId);
    }
}

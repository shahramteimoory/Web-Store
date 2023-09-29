using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}

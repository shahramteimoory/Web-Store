using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        public ResultDto Execute(RequestEdituserDto request);
    }
}

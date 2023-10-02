using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUserService
    {
        private readonly IDataBaseContext _context;

        public GetUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.users.Include(u=>u.UserInRoles).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(u => u.FullName.Contains(request.SearchKey) || u.Email.Contains(request.SearchKey));
            }
            int rowscount = 0;
            var userlist = users.ToPaged(request.Page, 20, out rowscount).Select(u => new GetUserDto
            {
                Email = u.Email,
                FullName = u.FullName,
                Id = u.Id,
                IsActive = u.IsActive,
                Roles=u.UserInRoles.FirstOrDefault().RoleID.ToString()
                //GetRoles(u.UserInRoles)
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowscount,
                Users = userlist
            };
        
        }
    }
}

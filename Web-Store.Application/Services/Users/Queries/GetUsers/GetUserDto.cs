using System.Collections.Generic;
using Web_Store.Application.Services.Users.Queries.GetRoles;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUserDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Roles { get; set; }
    }
}

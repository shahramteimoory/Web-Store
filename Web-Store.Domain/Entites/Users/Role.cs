using System.Collections.Generic;

namespace Web_Store.Domain.Entites.Users
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}

using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.Users
{
    public class Role : BaseEntites
    {
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}

using Web_Store.Domain.Entites.Commons;
using Web_Store.Domain.Entites.Orders;

namespace Web_Store.Domain.Entites.Users
{
    public class User : BaseEntites
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}

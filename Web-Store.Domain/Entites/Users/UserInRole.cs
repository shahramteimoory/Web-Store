namespace Web_Store.Domain.Entites.Users
{
    public class UserInRole
    {
        public long Id { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public long RoleID { get; set; }


    }
}

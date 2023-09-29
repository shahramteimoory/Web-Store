namespace Web_Store.Application.Services.Users.Commands.EditUser
{
    public class RequestEdituserDto
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
    }
}

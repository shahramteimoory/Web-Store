using System.Collections.Generic;

namespace Web_Store.Application.Services.Users.Commands.UserLogin
{
    public class ResultUserloginDto
    {
        public long UserId { get; set; }
        public List<string> Roles { get; set; }
        public string Name { get; set; }
    }
}

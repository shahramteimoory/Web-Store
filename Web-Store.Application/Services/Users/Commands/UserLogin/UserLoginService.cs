using Microsoft.EntityFrameworkCore;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Users.Commands.UserLogin
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;
        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserloginDto> Execute(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "لطفا نام کاربری و رمز عبور را وارد کنید"
                };
            }

            var user = _context.users
                .Include(u => u.UserInRoles)
                .ThenInclude(u => u.Role)
                .Where(p => p.Email.Equals(username) && p.IsActive == true).FirstOrDefault();

            if (user == null)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto() { },
                    IsSuccess = false,
                    Message = "این کاربر در سایت ثبت نام نکرده است"
                };
            }
            var passwordHasher = new PasswordHasher();
            bool resultpassword = passwordHasher.VerifyPassword(user.Password, password);

            if (resultpassword == false)
            {
                return new ResultDto<ResultUserloginDto>
                {
                    Data = new ResultUserloginDto() { },
                    IsSuccess = false,
                    Message = "رمز عبور اشتباه وارد شده"
                };
            }
            List<string> Role = new List<string>();
            foreach (var item in user.UserInRoles)
            {
                Role.Add(item.Role.Name);
            }

            return new ResultDto<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto()
                {
                    Name = user.FullName,
                    Roles = Role,
                    UserId = user.Id,
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد"

            };
        }
    }
}

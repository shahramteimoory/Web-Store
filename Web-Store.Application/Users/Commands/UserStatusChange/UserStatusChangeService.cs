using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Users.Commands.UserStatusChange
{
    public class UserStatusChangeService : IUserStatusChangeService
    {
        private readonly IDataBaseContext _context;

        public UserStatusChangeService(IDataBaseContext context)
        {
            _context= context;
        }
        public ResultDto Execute(long UserId)
        {
            var user=_context.users.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            //state یزر رو میریزه تو متغیر
            string userstate = user.IsActive == true ? "فعال  " : "  غیرفعال ";
            return new ResultDto {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userstate}شد ! " 
            };
        }
    }
}

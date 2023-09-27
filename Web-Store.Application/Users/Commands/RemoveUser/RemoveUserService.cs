using System;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        public readonly IDataBaseContext _context;

        public RemoveUserService(IDataBaseContext Context)
        {
            _context = Context;
        }
        public ResultDto Execute(long UserId)
        {
            var user = _context.users.Find(UserId);
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            user.IsActive = false;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}

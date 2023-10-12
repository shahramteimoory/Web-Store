using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long UserId);
    }
}

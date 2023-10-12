using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long UserId);
    }
}

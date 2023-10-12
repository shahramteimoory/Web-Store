using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Commands.DeleteImagesSite
{
    public interface IDeleteHomeImagesService
    {
        ResultDto Execute(long imageId);
    }
}

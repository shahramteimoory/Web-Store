using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Commands.DeleteImagesSite
{
    public interface IDeleteHomeImagesService
    {
        ResultDto Execute(long imageId);
    }
}

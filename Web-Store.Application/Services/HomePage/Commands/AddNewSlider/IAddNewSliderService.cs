using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.HomePage.Commands.AddNewSlider
{
    public interface IAddNewSliderService
    {
        ResultDto Execute (IFormFile file,string Link,string Name);
    }
    
}

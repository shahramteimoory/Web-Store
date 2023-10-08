using Microsoft.AspNetCore.Http;
using Web_Store.Domain.Entites.HomePage;

namespace Web_Store.Application.Services.HomePage.Commands.AddHomePageImages
{
    public class RequestAddHomePageImagesDto
    {
        public IFormFile File { get; set; }
        public string Link { get; set; }
        public ImageLocation imageLocation { get; set; }
    }
}

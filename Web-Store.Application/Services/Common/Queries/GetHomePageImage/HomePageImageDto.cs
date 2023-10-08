using Web_Store.Domain.Entites.HomePage;

namespace Web_Store.Application.Services.Common.Queries.GetHomePageImage
{
    public class HomePageImageDto
    {
        public string Src { get; set; }
        public long Id { get; set; }
        public string Link { get; set; }
        public ImageLocation imageLocation {  get; set; }
        
    }
}

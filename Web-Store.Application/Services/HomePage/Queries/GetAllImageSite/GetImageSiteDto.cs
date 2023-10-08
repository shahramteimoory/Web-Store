using Web_Store.Domain.Entites.HomePage;

namespace Web_Store.Application.Services.HomePage.Queries.GetAllImageSite
{
    public class GetImageSiteDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation imageLocation { get; set; }
    }
}

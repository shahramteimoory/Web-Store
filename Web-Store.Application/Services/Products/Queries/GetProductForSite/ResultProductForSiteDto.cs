using System.Collections.Generic;

namespace Web_Store.Application.Services.Products.Queries.GetProductForSite
{
    public class ResultProductForSiteDto
    {
        public List<ProductForSiteDto> products { get; set; }
        public int TotalRow { get; set; }
    }
}

using System.Collections.Generic;

namespace Web_Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ProductsForAdminList_Dto> products {  get; set; }
    }
}

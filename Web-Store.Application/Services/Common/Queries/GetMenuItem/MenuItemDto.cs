using System.Collections.Generic;

namespace Web_Store.Application.Services.Common.Queries.GetMenuItem
{
    public class MenuItemDto
    {
        public long CatId { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Child { get; set;}
    }
}

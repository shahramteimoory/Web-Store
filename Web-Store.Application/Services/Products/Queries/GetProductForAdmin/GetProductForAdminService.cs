using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _context= context;
        }
        public ResultDto<ProductForAdminDto> Execute(int page = 1, int pagesize = 20)
        {
            int rowcount = 0;
            var product = _context.products
                .Include(p => p.Category)
                .ToPaged(page, pagesize, out rowcount).Select(p => new ProductsForAdminList_Dto
                {
                    Id = p.Id,
                    Brand=p.Brand,
                    Category=p.Category.Name,
                    Description=p.Description,
                    Inventory=p.Inventory,
                    Displayed=p.Display,
                    Name=p.Name,
                    Price=p.Price,
                }).ToList();
            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto()
                {
                    products = product,
                    CurrentPage=page,
                    PageSize=pagesize,
                    RowCount=rowcount
                },
                IsSuccess=true,
                Message=""
                
            };
        }
    }
}

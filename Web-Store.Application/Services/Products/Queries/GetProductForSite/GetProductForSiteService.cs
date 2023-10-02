using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Queries.GetProductForSite
{
    public class GetProductForSiteService : IGetProductForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetProductForSiteService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<ResultProductForSiteDto> Execute(int page )
        {
            int totalRow = 0;
            var product = _context.products.Include(p=>p.ProductImages).Where(p=>p.Display==true).ToPaged(page, 5, out totalRow);

            //felan ke system coment nadarim mizanim random star bede bebinim kar mikone ya na
            Random rd = new Random();
            return new ResultDto<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalRow,
                    products = product.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Price =p.Price,

                    }).ToList(),
                },
                IsSuccess = true
            };
        }
    }
}

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
        public ResultDto<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, int page,int PageSize, long? CatId)
        {
            int totalRow = 0;
            var productQuery = _context.products.Include(p => p.ProductImages)
                .Where(p => p.Display == true).AsQueryable();
            if (CatId!=null)
            {
                productQuery=productQuery.Where(p=>p.CategoryId == CatId || p.Category.ParentCategoryId==CatId).AsQueryable();
            }
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                productQuery= productQuery.Where(c=>c.Name.Contains(SearchKey) || c.Brand.Contains(SearchKey)).AsQueryable();
            }
            switch (ordering)
            {
                case Ordering.NotOrder:
                    productQuery = productQuery.OrderByDescending(c=>c.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productQuery = productQuery.OrderByDescending(c => c.ViewCount).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    break;
                case Ordering.MostPopular:
                    break;
                case Ordering.theNewest:
                    productQuery = productQuery.OrderByDescending(c => c.Id).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    productQuery = productQuery.OrderBy(c => c.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    productQuery = productQuery.OrderByDescending(c => c.Price).AsQueryable();
                    break;
                default:
                    break;
            }

            var product= productQuery.ToPaged(page, PageSize, out totalRow);

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

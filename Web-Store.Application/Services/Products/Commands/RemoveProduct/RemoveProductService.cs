using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Products.Commands.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDataBaseContext _context;
        public RemoveProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long productId)
        {
            try
            {
                var product = _context.products.Find(productId);
                if (product == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "محصول مورد نظر پیدا نشد"
                    };
                }
                product.RemoveTime = DateTime.Now;
                product.IsRemoved = true;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول مورد نظر با موفقیت حذف شد"
                };
            }
            catch
            {

                return new ResultDto { IsSuccess = false, Message = "خطایی در عملیات حذف محصول رخ داده" };
            }
        }
    }
}

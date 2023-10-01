using FluentValidation;
using Web_Store.Domain.Entites.Products;

namespace Web_Store.Application.Interfaces.FluentValidation
{
    public class Validation : AbstractValidator<Product>
    {
        public Validation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("نام الزامی است.");
            RuleFor(p => p.Brand).NotEmpty().WithMessage("نام خانوادگی الزامی است.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("توضیحات رو بنویسید.");
            RuleFor(p => p.Price).InclusiveBetween(3, 18).WithMessage("قیمت را به درستی وارد کنید");
            RuleFor(p => p.Inventory).NotEmpty().WithMessage("مقدار نمیتواند در انبار کمتر از 1 باشد");
            RuleFor(p => p.Category).NotEmpty().WithMessage("لطفا یک دسته بندی انتخاب کنید");
            // قواعد اعتبارسنجی دیگر...

        }
    }
}

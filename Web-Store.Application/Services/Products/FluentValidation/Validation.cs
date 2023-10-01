using FluentValidation;
using Web_Store.Domain.Entites.Products;

namespace Web_Store.Application.Services.Products.FluentValidation
{
    public class Validation : AbstractValidator<Product>
    {
        public Validation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("نام الزامی است.");
            RuleFor(p => p.Brand).NotEmpty().WithMessage("برند الزامی است.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("توضیحات رو بنویسید.");
            RuleFor(p => p.Inventory).NotEmpty().WithMessage("مقدار نمیتواند در انبار کمتر از 1 باشد");
            // قواعد اعتبارسنجی دیگر...

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Web_Store.Domain.Entites.Orders
{
    public enum OrderState
    {
        [Display(Name ="در حال انجام")]
        Processing=0,
        [Display(Name ="لغو شده")]
        Canceled=1,
        [Display(Name ="دریافت شده")]
        Delivered=2
    }
}

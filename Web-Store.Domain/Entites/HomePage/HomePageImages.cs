using System.ComponentModel.DataAnnotations;
using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.HomePage
{
    public class HomePageImages : BaseEntites
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation imageLocation { get; set; }
    }
    public enum ImageLocation
    {
        [Display(Name = "تصویر اول سمت چپ")]
        L1 = 0,
        [Display(Name = "تصویر دوم سمت چپ")]
        L2 = 1,
        [Display(Name = "تصویر اول سمت راست")]
        R1 = 2,

        [Display(Name = "نوار سراسری در وسط صفحه")]
        CenterFullScreen = 3,

        [Display(Name = "گروه تصاویر اول")]
        G1 = 4,

        [Display(Name = "گروه تصاویر دوم")]
        G2 = 5,
    }
}

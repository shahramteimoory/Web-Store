using System.ComponentModel.DataAnnotations;

namespace EndPoint.site.Models.ViewModels.AuthenticationViewModel
{
    public class SignupViewModel
    {

        [Required(ErrorMessage = "نام و نام خانوادگی را وارد نمایید")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نمی‌باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
        [MinLength(8, ErrorMessage = "رمز عبور باید حداقل 8 کاراکتر باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار رمز عبور را وارد نمایید")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن برابر نیستند")]
        public string RePassword { get; set; }
    }
}


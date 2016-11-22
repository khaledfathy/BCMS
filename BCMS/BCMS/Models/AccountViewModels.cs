using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BCMS.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage ="من فضلك ادخل البريد الإلكترونى")]
        [Display(Name = "البريد الإلكترونى")]
        //[EmailAddress(ErrorMessage ="البريد الإلكترونى غير صحيح")]
        public string Email { get; set; }

        [Required(ErrorMessage ="من فضلك ادخل كلمة المرور")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Display(Name = "تذكرنى؟")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [MinLength(2, ErrorMessage = "يجب ان يكون الاسم مكون من حرفان على الاقل")]
        [MaxLength(15)]
        [Required(ErrorMessage = "ادخل الاسم الاول")]
        [RegularExpression(@"^[a-zA-Z أاإ-ى]+$")]
        [Display(Name = "الاسم الاول")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "يجب ان يكون الاسم مكون من حرفان على الاقل")]
        [MaxLength(15)]
        [Display(Name = "اسم الاب")]
        [RegularExpression(@"^[a-zA-Z أاإ-ى]+$")]
        public string MiddleName { get; set; }

        [MinLength(2, ErrorMessage = "يجب ان يكون الاسم مكون من حرفان على الاقل")]
        [MaxLength(15)]
        [Required(ErrorMessage = "ادخل اسم العائلة")]
        [Display(Name = "اسم العائلة")]
        [RegularExpression(@"^[a-zA-Z أاإ-ى]+$")]
        public string LastName { get; set; }

        [Display(Name = "إسم المستخدم")]
        [Required(ErrorMessage = "ادخل إسم المستخدم")]
        [RegularExpression(@"^(?=.{3,20}$)(?![-_.0-9])(?!.*[_.-]{2})[a-zA-Z0-9._-]+(?![_.-])$", ErrorMessage = "UserName is invalid")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ادخل البريد الالكترونى")]
        [EmailAddress]
        [Display(Name = "البريد الالكترونى")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ادخل كلمة المرور")]
        [Display(Name = "كلمة المرور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "برجاء تأكيد كلمة المرور")]
        [Display(Name = "تأكيد كلمةالمرور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string ConfirmPassword { get; set; }


    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])+(?=.*[A-Z])(?=.*[@#$%!%=+]).{8,20})", ErrorMessage = "كلمة المرور لا تقل عن 8 احرف كبيره وصغيره من بينهم رقم واحد على الاقل واحرف خاصة مثل'@،#،$،%،!،_،-،=،+ ...'واحد على الاقل")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

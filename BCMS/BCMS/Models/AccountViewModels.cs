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
        [EmailAddress(ErrorMessage ="البريد الإلكترونى غير صحيح")]
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
        [Required(ErrorMessage = "ادخل الاسم الاول")]
        [Display(Name = "الاسم الاول")]
        public string FirstName { get; set; }

        [Display(Name = "اسم الاب")]
        public string MiddleName { get; set; }

        [MinLength(2, ErrorMessage = "يجب ان يكون الاسم مكون من حرفان على الاقل")]
        [Required(ErrorMessage = "ادخل اسم العائلة")]
        [Display(Name = "اسم العائلة")]
        public string LastName { get; set; }

        [MinLength(2, ErrorMessage = "يجب ان يكون الاسم مكون من حرفان على الاقل")]
        [Display(Name = "إسم المستخدم")]
        [Required(ErrorMessage = "ادخل إسم المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ادخل البريد الالكترونى")]
        //[RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]{2,4}$", ErrorMessage = "البريد الالكترونى غير صحيح")]
        [EmailAddress]
        [Display(Name = "البريد الالكترونى")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ادخل كلمة المرور")]
        [Display(Name = "كلمة المرور")]
        //[RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*?[#?!@$%^&*-]){8,20}$",ErrorMessage="كلمة المرور لا تقل عن 8 احرف من بينهم رقم واحد على الاقل واحرف  خاصة مثل '@ # $ ... ' واحد على الاقل")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])+(?=.*[A-Z])(?=.*[@#$%!%=+]).{8,20})", ErrorMessage = "كلمة المرور لا تقل عن 8 احرف كبيره وصغيره من بينهم رقم واحد على الاقل واحرف خاصة مثل'@،#،$،%،!،_،-،=،+ ...'واحد على الاقل")]
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
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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

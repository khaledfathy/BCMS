using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCMS.Models
{
    public class ContactUs
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب كتابة الإسم")]
        public string name { get; set; }

        [EmailAddress(ErrorMessage="يجب كتابة البريد الإلكتروني بصيغة صحيحة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب كتابة البريد الإلكتروني")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب كتابة الموضوع")]
        public string subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "يجب كتابة الرسالة")]
        public string message { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCMS.Models
{
    public class EditNameView
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
    }
}
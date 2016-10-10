namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faq")]
    public partial class Faq
    {
        public int FaqID { get; set; }

        [Required]
        public string FaqQuestion { get; set; }

        [Required]
        public string FaqAnswer { get; set; }
    }
}

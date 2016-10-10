namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamResult")]
    public partial class ExamResult
    {
        [Key]
        public int result_id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        public int? subcategory_id { get; set; }

        public int correct_a { get; set; }

        public int wrong_a { get; set; }

        public int not_answered { get; set; }

        public virtual ExamSubCategory ExamSubCategory { get; set; }
    }
}

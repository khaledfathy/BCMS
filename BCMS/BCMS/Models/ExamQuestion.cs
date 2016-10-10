namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamQuestion")]
    public partial class ExamQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamQuestion()
        {
            ExamAnswer_question = new HashSet<ExamAnswer_question>();
        }

        public int id { get; set; }

        public int? subcategory_id { get; set; }

        [Required]
        [StringLength(4000)]
        public string quiz_text { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAnswer_question> ExamAnswer_question { get; set; }

        public virtual ExamSubCategory ExamSubCategory { get; set; }
    }
}

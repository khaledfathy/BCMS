namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamTrueOrFalse")]
    public partial class ExamTrueOrFalse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamTrueOrFalse()
        {
            ExamAnswer_question = new HashSet<ExamAnswer_question>();
        }

        public bool id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? Tid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAnswer_question> ExamAnswer_question { get; set; }
    }
}

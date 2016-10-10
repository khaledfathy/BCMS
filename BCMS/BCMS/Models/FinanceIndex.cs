namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinanceIndex")]
    public partial class FinanceIndex
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinanceIndex()
        {
            FinanceIndexValues = new HashSet<FinanceIndexValue>();
        }

        public int Id { get; set; }

        [StringLength(70)]
        public string FinanceIndexName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceIndexValue> FinanceIndexValues { get; set; }
    }
}

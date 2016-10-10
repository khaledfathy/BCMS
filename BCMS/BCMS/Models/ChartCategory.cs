namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChartCategory")]
    public partial class ChartCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChartCategory()
        {
            ChartAnalysesKinds = new HashSet<ChartAnalysesKind>();
        }

        public int ChartCategoryId { get; set; }

        [StringLength(50)]
        public string ChartCategoryName { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChartAnalysesKind> ChartAnalysesKinds { get; set; }
    }
}

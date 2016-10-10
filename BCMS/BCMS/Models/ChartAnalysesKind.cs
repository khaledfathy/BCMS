namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChartAnalysesKind")]
    public partial class ChartAnalysesKind
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChartAnalysesKind()
        {
            Charts = new HashSet<Chart>();
        }

        [Key]
        public int CAKId { get; set; }

        [StringLength(50)]
        public string CAKName { get; set; }

        public string Description { get; set; }

        public int? ChartCategoryId { get; set; }

        public int? ImgId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chart> Charts { get; set; }

        public virtual ChartCategory ChartCategory { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            Activity_Year = new HashSet<Activity_Year>();
        }

        public short ActivityId { get; set; }

        [StringLength(50)]
        public string ActivityArName { get; set; }

        [StringLength(50)]
        public string ActivityEngName { get; set; }

        public short? ActivityCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity_Year> Activity_Year { get; set; }
    }
}

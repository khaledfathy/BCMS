namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elder()
        {
            WiseSayings = new HashSet<WiseSaying>();
        }

        [Key]
        public short EldersID { get; set; }

        [StringLength(100)]
        public string EldersName { get; set; }

        public string EldersDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WiseSaying> WiseSayings { get; set; }
    }
}

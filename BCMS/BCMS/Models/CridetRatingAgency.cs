namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CridetRatingAgency")]
    public partial class CridetRatingAgency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CridetRatingAgency()
        {
            Country_CreditRatingAgency = new HashSet<Country_CreditRatingAgency>();
            Evaluations = new HashSet<Evaluation>();
            Region_CreditRatingAgency = new HashSet<Region_CreditRatingAgency>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte AgencyId { get; set; }

        [StringLength(50)]
        public string AgencyArName { get; set; }

        [StringLength(50)]
        public string AgencyEnName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Country_CreditRatingAgency> Country_CreditRatingAgency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluation> Evaluations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Region_CreditRatingAgency> Region_CreditRatingAgency { get; set; }
    }
}

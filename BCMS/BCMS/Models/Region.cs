namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Region")]
    public partial class Region
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Region()
        {
            GasConsumptionRegions = new HashSet<GasConsumptionRegion>();
            GasProductionRegions = new HashSet<GasProductionRegion>();
            GasReservedRegions = new HashSet<GasReservedRegion>();
            OilConsumptionRegions = new HashSet<OilConsumptionRegion>();
            OilProductionRegions = new HashSet<OilProductionRegion>();
            OilReservedRegions = new HashSet<OilReservedRegion>();
            OtherOilConsumptionRegions = new HashSet<OtherOilConsumptionRegion>();
            OtherOilProductionRegions = new HashSet<OtherOilProductionRegion>();
            OtherOilReservedRegions = new HashSet<OtherOilReservedRegion>();
            Region_CreditRatingAgency = new HashSet<Region_CreditRatingAgency>();
            Countries = new HashSet<Country>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte RegionId { get; set; }

        [StringLength(250)]
        public string RegionArName { get; set; }

        [StringLength(250)]
        public string RegionEnName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasConsumptionRegion> GasConsumptionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasProductionRegion> GasProductionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasReservedRegion> GasReservedRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilConsumptionRegion> OilConsumptionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilProductionRegion> OilProductionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilReservedRegion> OilReservedRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherOilConsumptionRegion> OtherOilConsumptionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherOilProductionRegion> OtherOilProductionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherOilReservedRegion> OtherOilReservedRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Region_CreditRatingAgency> Region_CreditRatingAgency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Country> Countries { get; set; }
    }
}

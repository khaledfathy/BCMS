namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherOilConsumptionRegion")]
    public partial class OtherOilConsumptionRegion
    {
        [Key]
        public int OtherId { get; set; }

        [StringLength(50)]
        public string OtherRegionArName { get; set; }

        [StringLength(50)]
        public string OtherRegionEnName { get; set; }

        public decimal? OilConsumptionBarrelValue { get; set; }

        public decimal? OilConsumptionTonneValue { get; set; }

        public int? YearId { get; set; }

        public byte? RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}

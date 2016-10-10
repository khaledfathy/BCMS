namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OilConsumptionRegion")]
    public partial class OilConsumptionRegion
    {
        [Key]
        public int OilConsumptionId { get; set; }

        public decimal? OilConsumptionByBarrel { get; set; }

        public decimal? OilConsumptionByTonne { get; set; }

        public byte? RegionId { get; set; }

        public int? YearId { get; set; }

        public virtual Region Region { get; set; }

        public virtual Year Year { get; set; }
    }
}

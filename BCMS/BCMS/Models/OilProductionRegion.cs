namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OilProductionRegion")]
    public partial class OilProductionRegion
    {
        [Key]
        public int OilProductionId { get; set; }

        public decimal? OilProductionByBarrel { get; set; }

        public decimal? OilProductionByTonne { get; set; }

        public byte? RegionId { get; set; }

        public int? YearId { get; set; }

        public virtual Region Region { get; set; }

        public virtual Year Year { get; set; }
    }
}

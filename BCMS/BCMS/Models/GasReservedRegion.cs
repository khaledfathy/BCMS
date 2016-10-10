namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GasReservedRegion")]
    public partial class GasReservedRegion
    {
        [Key]
        public int GasReservesId { get; set; }

        public decimal? GasReservesByCubicMetres { get; set; }

        public decimal? GasReservesByTonne { get; set; }

        public byte? RegionId { get; set; }

        public int? YearId { get; set; }

        public virtual Region Region { get; set; }

        public virtual Year Year { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherOilReservedRegion")]
    public partial class OtherOilReservedRegion
    {
        [Key]
        public int OtherId { get; set; }

        [StringLength(50)]
        public string OtherRegionArName { get; set; }

        [StringLength(50)]
        public string OtherRegionEnName { get; set; }

        public decimal? ProvedReservesBarrelValue { get; set; }

        public decimal? ProvedReservesTonlValue { get; set; }

        public int? YearId { get; set; }

        public byte? RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}

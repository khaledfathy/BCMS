namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OilReservedRegion")]
    public partial class OilReservedRegion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProvedReservesId { get; set; }

        public decimal? ProvedReservesBarrelValue { get; set; }

        public decimal? ProvedReservesTonlValue { get; set; }

        public byte? RegionId { get; set; }

        public int? YearId { get; set; }

        public virtual Region Region { get; set; }

        public virtual Year Year { get; set; }
    }
}

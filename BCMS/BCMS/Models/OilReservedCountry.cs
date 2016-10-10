namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OilReservedCountry")]
    public partial class OilReservedCountry
    {
        [Key]
        public int ProvedReservesId { get; set; }

        public decimal? ProvedReservesBarrelValue { get; set; }

        public decimal? ProvedReservesTonlValue { get; set; }

        public short? CountryId { get; set; }

        public int? YearId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Year Year { get; set; }
    }
}

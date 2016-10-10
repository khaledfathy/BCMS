namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GasReservedCountry")]
    public partial class GasReservedCountry
    {
        [Key]
        public int GasReservesId { get; set; }

        public decimal? GasReservesByCubicMetres { get; set; }

        public decimal? GasReservesByTonne { get; set; }

        public short? CountryId { get; set; }

        public int? YearId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Year Year { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GasProductionCountry")]
    public partial class GasProductionCountry
    {
        [Key]
        public int GasProductionId { get; set; }

        public decimal? GasProductionByBCM { get; set; }

        public decimal? GasProductionByBCF { get; set; }

        public decimal? GasProductionByTonne { get; set; }

        public short? CountryId { get; set; }

        public int? YearId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Year Year { get; set; }
    }
}

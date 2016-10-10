namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GasConsumptionCountry")]
    public partial class GasConsumptionCountry
    {
        [Key]
        public int GasConsumptionId { get; set; }

        public decimal? GasConsumptionByBCM { get; set; }

        public decimal? GasConsumptionByBCF { get; set; }

        public decimal? GasConsumptionByTonne { get; set; }

        public short? CountryId { get; set; }

        public int? YearId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Year Year { get; set; }
    }
}

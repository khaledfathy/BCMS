namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OilConsumptionCountry")]
    public partial class OilConsumptionCountry
    {
        [Key]
        public int OilConsumptionId { get; set; }

        public decimal? OilConsumptionByBarrel { get; set; }

        public decimal? OilConsumptionByTonne { get; set; }

        public short? CountryId { get; set; }

        public int? YearId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Year Year { get; set; }
    }
}

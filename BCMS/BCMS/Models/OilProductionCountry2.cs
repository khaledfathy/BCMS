namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OilProductionCountry2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OilProductionId { get; set; }

        public decimal? OilProductionByBarrel { get; set; }

        public decimal? OilProductionByTonne { get; set; }

        public short? CountryId { get; set; }

        public int? YearId { get; set; }

        public virtual Country Country { get; set; }

        public virtual Year Year { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MiseryIndex")]
    public partial class MiseryIndex
    {
        [Key]
        public long MiseryId { get; set; }

        public short? MarketID { get; set; }

        public int? YearId { get; set; }

        public decimal? RateOfInflation { get; set; }

        public decimal? UnemploymentRate { get; set; }

        public virtual Market Market { get; set; }

        public virtual Year Year { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YearlyValueTraded")]
    public partial class YearlyValueTraded
    {
        [Key]
        public long ValueTradedId { get; set; }

        public decimal? ValueTraded { get; set; }

        public int? YearId { get; set; }

        public short? MarketId { get; set; }

        public virtual Market Market { get; set; }

        public virtual Year Year { get; set; }
    }
}

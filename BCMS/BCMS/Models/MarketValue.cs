namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarketValue")]
    public partial class MarketValue
    {
        public long MarketValueId { get; set; }

        [Column("MarketValue")]
        public decimal? MarketValue1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public short? MarketId { get; set; }

        public virtual Market Market { get; set; }
    }
}

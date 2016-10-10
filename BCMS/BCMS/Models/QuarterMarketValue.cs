namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuarterMarketValue")]
    public partial class QuarterMarketValue
    {
        [Key]
        public long MarketValueId { get; set; }

        public short? QuarterId { get; set; }

        public decimal? MarketValue { get; set; }

        public short? MarketId { get; set; }

        public short? Date { get; set; }

        public decimal? ValueTradedOfStocks { get; set; }

        public decimal? DailyAvaregeValueTraded { get; set; }

        public decimal? NumberOfStockTraded { get; set; }

        public decimal? DailyAverageOfStockTraded { get; set; }

        public short? NumberOfListedCompanies { get; set; }

        public virtual Market Market { get; set; }
    }
}

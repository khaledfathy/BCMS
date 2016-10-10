namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarketAnalyse")]
    public partial class MarketAnalyse
    {
        [Key]
        public long marketAnalysisId { get; set; }

        public decimal? IssuedShares { get; set; }

        public decimal? FloatedShares { get; set; }

        public decimal? NetIncome { get; set; }

        public decimal? ShareHoldersEquity { get; set; }

        public decimal? MarketCap { get; set; }

        public decimal? EPS { get; set; }

        public decimal? PE { get; set; }

        public decimal? BookValue { get; set; }

        public decimal? PBV { get; set; }

        public decimal? FloatedSharesMarketCap { get; set; }

        public int? YearId { get; set; }

        public short? MarketId { get; set; }

        public int? SectorId { get; set; }

        public virtual Market Market { get; set; }

        public virtual Sector Sector { get; set; }

        public virtual Year Year { get; set; }
    }
}

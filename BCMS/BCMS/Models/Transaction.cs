namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int TransactionId { get; set; }

        public decimal? TransactionValue { get; set; }

        public decimal? TradedStock { get; set; }

        public decimal? TradedStocksValue { get; set; }

        public int? SectorId { get; set; }

        public virtual Sector Sector { get; set; }
    }
}

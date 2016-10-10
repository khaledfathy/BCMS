namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinanceIndexValue")]
    public partial class FinanceIndexValue
    {
        public int ID { get; set; }

        public decimal? IndexValue { get; set; }

        public int? YearId { get; set; }

        public int? FinanceIndexId { get; set; }

        public virtual FinanceIndex FinanceIndex { get; set; }

        public virtual Year Year { get; set; }
    }
}

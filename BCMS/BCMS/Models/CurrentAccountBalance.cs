namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrentAccountBalance")]
    public partial class CurrentAccountBalance
    {
        public int CurrentAccountBalanceId { get; set; }

        public short? CountryId { get; set; }

        public int? SubjectId { get; set; }

        public int? YearId { get; set; }

        public decimal? Value { get; set; }

        public decimal? ValuePercentage { get; set; }

        public virtual Country Country { get; set; }

        public virtual subject subject { get; set; }

        public virtual Year Year { get; set; }
    }
}

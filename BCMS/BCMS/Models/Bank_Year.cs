namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bank_Year
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YearId { get; set; }

        public int? ATMMachine { get; set; }

        public int? BranchsBank { get; set; }

        public decimal? PercentageGrowthBranchsBank { get; set; }

        public decimal? PercentageGrowthATMMachine { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual Year Year { get; set; }
    }
}

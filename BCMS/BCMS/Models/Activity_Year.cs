namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Activity_Year
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ActivityId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YearId { get; set; }

        public decimal? ActivityValue { get; set; }

        public decimal? CurrentActivityValue { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Year Year { get; set; }
    }
}

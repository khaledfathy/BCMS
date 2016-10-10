namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chart")]
    public partial class Chart
    {
        public int ChartId { get; set; }

        [StringLength(150)]
        public string ChartName { get; set; }

        public string ChartScript { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PuplishDate { get; set; }

        public string Description { get; set; }

        public int? CAKId { get; set; }

        public virtual ChartAnalysesKind ChartAnalysesKind { get; set; }
    }
}

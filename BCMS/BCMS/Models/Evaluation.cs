namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evaluation")]
    public partial class Evaluation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte EvaluationId { get; set; }

        [StringLength(10)]
        public string EvaluationText { get; set; }

        public byte? AgencyId { get; set; }

        public string Description { get; set; }

        public virtual CridetRatingAgency CridetRatingAgency { get; set; }
    }
}

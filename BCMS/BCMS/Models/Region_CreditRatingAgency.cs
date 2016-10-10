namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Region_CreditRatingAgency
    {
        [Key]
        [Column(Order = 0)]
        public byte RegionId { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte AgencyId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Year { get; set; }

        public byte? PeriodId { get; set; }

        public string Excpectation { get; set; }

        [StringLength(10)]
        public string Evaluation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Excpectation_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Evaluation_date { get; set; }

        public virtual CridetRatingAgency CridetRatingAgency { get; set; }

        public virtual Region Region { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country_CreditRatingAgency
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CountryId { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte AgencyId { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte PeriodId { get; set; }

        public short? Year { get; set; }

        public string Excpectation { get; set; }

        [StringLength(10)]
        public string Evaluation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Excpectation_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Evaluation_Date { get; set; }

        public int? AsumptionValue { get; set; }

        public virtual Country Country { get; set; }

        public virtual CridetRatingAgency CridetRatingAgency { get; set; }
    }
}

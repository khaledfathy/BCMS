namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tadawel")]
    public partial class Tadawel
    {
        [Key]
        public double CODE { get; set; }

        [StringLength(255)]
        public string NAME { get; set; }

        public double? CASHFLOWIN { get; set; }

        public double? CASHFLOWOUT { get; set; }

        [StringLength(255)]
        public string TREND { get; set; }

        [StringLength(255)]
        public string CHANGE { get; set; }

        [StringLength(255)]
        public string CHANGEPEST { get; set; }

        [StringLength(255)]
        public string BESTASKQ { get; set; }

        [StringLength(255)]
        public string BESTBIDP { get; set; }

        [StringLength(255)]
        public string BESTBIDQ { get; set; }

        [StringLength(255)]
        public string VOLUME { get; set; }

        [StringLength(255)]
        public string VALUE { get; set; }

        [StringLength(255)]
        public string TRANSACTIONS { get; set; }

        [StringLength(255)]
        public string ASKBID { get; set; }

        [Required]
        [StringLength(255)]
        public string CASHFLOWPLAN { get; set; }

        public int RecordID { get; set; }

        public virtual Sector Sector { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TadSheet")]
    public partial class TadSheet
    {
        [Key]
        public double CODE { get; set; }

        [StringLength(255)]
        public string NAME { get; set; }

        [StringLength(255)]
        public string SECTOR { get; set; }

        public double? LASTPRICE { get; set; }

        public double? CHANGE { get; set; }

        public double? CHANGEPER { get; set; }

        public double? BESTASKP { get; set; }

        public double? BESTASKQ { get; set; }

        public double? BESTBIDP { get; set; }

        public double? BESTBIDQ { get; set; }

        public double? VOLUME { get; set; }

        public double? VALUE { get; set; }

        public double? TRANSACTIONS { get; set; }

        [StringLength(255)]
        public string ASKBID { get; set; }

        public double? OPENP { get; set; }
    }
}

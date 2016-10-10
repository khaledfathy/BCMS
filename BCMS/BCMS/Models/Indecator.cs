namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Indecator")]
    public partial class Indecator
    {
        public short IndecatorId { get; set; }

        [StringLength(50)]
        public string IndecatorArName { get; set; }

        [StringLength(50)]
        public string IndecatorEnName { get; set; }

        public short? Marketid { get; set; }

        public virtual Market Market { get; set; }
    }
}

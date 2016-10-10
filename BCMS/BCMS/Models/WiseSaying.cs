namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WiseSaying")]
    public partial class WiseSaying
    {
        public int WiseSayingID { get; set; }

        public string WiseSayingContent { get; set; }

        public short? EldersID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WiseSayingDate { get; set; }

        public int? StatusID { get; set; }

        public virtual Elder Elder { get; set; }

        public virtual Status Status { get; set; }
    }
}

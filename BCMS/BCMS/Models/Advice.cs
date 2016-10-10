namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advice")]
    public partial class Advice
    {
        public int AdviceID { get; set; }

        public string AdviceContent { get; set; }

        public string AdviceDescription { get; set; }
    }
}

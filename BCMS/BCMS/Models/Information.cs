namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Information
    {
        public int InformationID { get; set; }

        public int KnowledgeID { get; set; }

        [Required]
        [StringLength(500)]
        public string InformationTitle { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}

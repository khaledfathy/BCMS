namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Job_Prefer
    {
        [Key]
        public int JPID { get; set; }

        public int JobID { get; set; }

        [Required]
        [StringLength(200)]
        public string Prefer { get; set; }

        public virtual Job Job { get; set; }
    }
}

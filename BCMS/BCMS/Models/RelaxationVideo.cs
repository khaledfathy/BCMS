namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelaxationVideo")]
    public partial class RelaxationVideo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte RelaxationVideoID { get; set; }

        [StringLength(100)]
        public string RelaxationVideoName { get; set; }
    }
}

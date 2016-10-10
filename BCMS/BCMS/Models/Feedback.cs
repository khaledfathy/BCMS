namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int FeedbackID { get; set; }

        [StringLength(100)]
        public string FeedbackName { get; set; }

        [StringLength(100)]
        public string FeedbackEmail { get; set; }

        public string FeedbackMessage { get; set; }
    }
}

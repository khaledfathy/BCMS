namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExamAnswer_question
    {
        public int? ques_id { get; set; }

        [StringLength(300)]
        public string answer { get; set; }

        public bool? is_right { get; set; }

        public int id { get; set; }

        public virtual ExamQuestion ExamQuestion { get; set; }

        public virtual ExamTrueOrFalse ExamTrueOrFalse { get; set; }
    }
}

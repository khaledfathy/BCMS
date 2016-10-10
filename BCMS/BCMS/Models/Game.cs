namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public int GameID { get; set; }

        [Required]
        public string GameName { get; set; }

        public string GameDescription { get; set; }

        [StringLength(100)]
        public string GameAuther { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GamePuplishDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GameCreatedDate { get; set; }

        [StringLength(100)]
        public string DevelopedBy { get; set; }

        [StringLength(100)]
        public string DesignedBy { get; set; }

        public int? StatusID { get; set; }

        public virtual Status Status { get; set; }
    }
}

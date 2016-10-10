namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyInfo")]
    public partial class CompanyInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }

        public int? SectorID { get; set; }

        public string CompanyShortName { get; set; }

        public string CompanyLongName { get; set; }

        public string CompanyActivity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompanyIncorporation { get; set; }

        public int? CompanyPaid_Up_Capital { get; set; }

        public int? CompanyEmployees { get; set; }

        public string CompanyMain_Office { get; set; }

        public string CompanyWork_sites { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompanyInfoDate { get; set; }

        public string ChairmanBoardOfDirectors { get; set; }

        public string CompanyDescription { get; set; }

        public string CompanyWebsite { get; set; }

        [StringLength(50)]
        public string Longitude { get; set; }

        [StringLength(50)]
        public string latitude { get; set; }

        public virtual Sector Sector { get; set; }
    }
}

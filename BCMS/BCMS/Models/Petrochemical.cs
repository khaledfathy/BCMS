using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCMS.Models
{
    public class Petrochemical
    {
        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Usage { get; set; }
        public decimal?  Price { get; set; }
        public double? Sabic36_Prod { get; set; }
        public double? Sabic36_Per { get; set; }
        public double? Petrochem_Prod { get; set; }
        public double? Petrochem_Per { get; set; }
        public double? Safco2_Prod { get; set; }
        public double? Safco2_Per { get; set; }
        public double? Kayan14_Prod { get; set; }
        public double? Kayan14_Per { get; set; }
        public double? Yansab15_Prod { get; set; }
        public double? Yansab15_Per { get; set; }
        public double? Sipchem8_Prod { get; set; }
        public double? Sipchem8_Per { get; set; }
        public double? Siig10_Prod { get; set; }
        public double? Siig10_Per { get; set; }
        public double? Tasnee8_Prod { get; set; }
        public double? Tasnee8_Per { get; set; }
        public double? Sahara8_Prod { get; set; }
        public double? Sahara8_Per { get; set; }
        public double? Chemanol10_Prod { get; set; }
        public double? Chemanol10_Per { get; set; }
        public double? Alujain1_Prod { get; set; }
        public double? Alujain1_Per { get; set; }
        public double? Advanced_Prod { get; set; }
        public double? Advanced_Per { get; set; }
        public double? Nama_Prod { get; set; }
        public double? Nama_Per { get; set; }
        public double? Rabigh8_Prod { get; set; }
        public double? Rabigh8_Per { get; set; }



    }
}
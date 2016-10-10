using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCMS.Areas.UTMS.Models
{
    public class OilItem
    {
        public decimal? Value { get; set; }
        public short? YearName { get; set; }
        public string RegionArName { get; set; }
        public string RegionEnName { get; set; }
        public string CountryArName { get; set; }
    }
}
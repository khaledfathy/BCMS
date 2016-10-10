namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Market")]
    public partial class Market
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Market()
        {
            Indecators = new HashSet<Indecator>();
            MarketAnalyses = new HashSet<MarketAnalyse>();
            MarketValues = new HashSet<MarketValue>();
            MiseryIndexes = new HashSet<MiseryIndex>();
            QuarterMarketValues = new HashSet<QuarterMarketValue>();
            YearlyValueTradeds = new HashSet<YearlyValueTraded>();
        }

        public short MarketId { get; set; }

        [StringLength(50)]
        public string MarketArName { get; set; }

        [StringLength(50)]
        public string MarketEnName { get; set; }

        public byte? MarketTypeId { get; set; }

        public short? EstablishedYear { get; set; }

        public short? CountryId { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Indecator> Indecators { get; set; }

        public virtual MarketType MarketType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketAnalyse> MarketAnalyses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketValue> MarketValues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiseryIndex> MiseryIndexes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuarterMarketValue> QuarterMarketValues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YearlyValueTraded> YearlyValueTradeds { get; set; }
    }
}

namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarketType")]
    public partial class MarketType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarketType()
        {
            Markets = new HashSet<Market>();
            MarketType1 = new HashSet<MarketType>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MarketTypeId { get; set; }

        [StringLength(50)]
        public string MarketTypeArName { get; set; }

        [StringLength(50)]
        public string MarkeTypeEnName { get; set; }

        public byte? ParentMarketTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Market> Markets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketType> MarketType1 { get; set; }

        public virtual MarketType MarketType2 { get; set; }
    }
}

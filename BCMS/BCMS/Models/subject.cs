namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subject()
        {
            CurrentAccountBalances = new HashSet<CurrentAccountBalance>();
            GoodsExportVolumes = new HashSet<GoodsExportVolume>();
            GoodsImportVolumes = new HashSet<GoodsImportVolume>();
            VolumeOfExportsOfGoodsAndServices = new HashSet<VolumeOfExportsOfGoodsAndService>();
            VolumeOfImportsOfGoodsAndServices = new HashSet<VolumeOfImportsOfGoodsAndService>();
            WorldGDPPriceFixeds = new HashSet<WorldGDPPriceFixed>();
        }

        public int SubjectId { get; set; }

        [Column("subject")]
        [StringLength(70)]
        public string subject1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrentAccountBalance> CurrentAccountBalances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsExportVolume> GoodsExportVolumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsImportVolume> GoodsImportVolumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolumeOfExportsOfGoodsAndService> VolumeOfExportsOfGoodsAndServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolumeOfImportsOfGoodsAndService> VolumeOfImportsOfGoodsAndServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorldGDPPriceFixed> WorldGDPPriceFixeds { get; set; }
    }
}

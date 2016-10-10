namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Country_CreditRatingAgency = new HashSet<Country_CreditRatingAgency>();
            CurrentAccountBalances = new HashSet<CurrentAccountBalance>();
            GasConsumptionCountries = new HashSet<GasConsumptionCountry>();
            GasProductionCountries = new HashSet<GasProductionCountry>();
            GasReservedCountries = new HashSet<GasReservedCountry>();
            GoodsExportVolumes = new HashSet<GoodsExportVolume>();
            GoodsImportVolumes = new HashSet<GoodsImportVolume>();
            Markets = new HashSet<Market>();
            OilConsumptionCountries = new HashSet<OilConsumptionCountry>();
            OilProductionCountry2 = new HashSet<OilProductionCountry2>();
            OilReservedCountries = new HashSet<OilReservedCountry>();
            VolumeOfExportsOfGoodsAndServices = new HashSet<VolumeOfExportsOfGoodsAndService>();
            VolumeOfImportsOfGoodsAndServices = new HashSet<VolumeOfImportsOfGoodsAndService>();
            WorldGDPPriceFixeds = new HashSet<WorldGDPPriceFixed>();
            Regions = new HashSet<Region>();
        }

        public short CountryId { get; set; }

        [StringLength(255)]
        public string CountryArName { get; set; }

        [StringLength(255)]
        public string CountryEnName { get; set; }

        [StringLength(255)]
        public string CountryCapitalAr { get; set; }

        [StringLength(255)]
        public string CountryCapitalEn { get; set; }

        public short? ContinentId { get; set; }

        public bool? State { get; set; }

        public virtual Continent Continent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Country_CreditRatingAgency> Country_CreditRatingAgency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrentAccountBalance> CurrentAccountBalances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasConsumptionCountry> GasConsumptionCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasProductionCountry> GasProductionCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasReservedCountry> GasReservedCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsExportVolume> GoodsExportVolumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsImportVolume> GoodsImportVolumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Market> Markets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilConsumptionCountry> OilConsumptionCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilProductionCountry2> OilProductionCountry2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilReservedCountry> OilReservedCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolumeOfExportsOfGoodsAndService> VolumeOfExportsOfGoodsAndServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolumeOfImportsOfGoodsAndService> VolumeOfImportsOfGoodsAndServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorldGDPPriceFixed> WorldGDPPriceFixeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Region> Regions { get; set; }
    }
}

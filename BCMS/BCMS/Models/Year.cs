namespace BCMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Year
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Year()
        {
            Activity_Year = new HashSet<Activity_Year>();
            Bank_Year = new HashSet<Bank_Year>();
            CurrentAccountBalances = new HashSet<CurrentAccountBalance>();
            FinanceIndexValues = new HashSet<FinanceIndexValue>();
            GasConsumptionCountries = new HashSet<GasConsumptionCountry>();
            GasConsumptionRegions = new HashSet<GasConsumptionRegion>();
            GasProductionCountries = new HashSet<GasProductionCountry>();
            GasProductionRegions = new HashSet<GasProductionRegion>();
            GasReservedCountries = new HashSet<GasReservedCountry>();
            GasReservedRegions = new HashSet<GasReservedRegion>();
            GoodsExportVolumes = new HashSet<GoodsExportVolume>();
            GoodsImportVolumes = new HashSet<GoodsImportVolume>();
            MarketAnalyses = new HashSet<MarketAnalyse>();
            MiseryIndexes = new HashSet<MiseryIndex>();
            OilConsumptionCountries = new HashSet<OilConsumptionCountry>();
            OilConsumptionRegions = new HashSet<OilConsumptionRegion>();
            OilProductionCountries = new HashSet<OilProductionCountry>();
            OilProductionRegions = new HashSet<OilProductionRegion>();
            OilReservedCountries = new HashSet<OilReservedCountry>();
            OilReservedRegions = new HashSet<OilReservedRegion>();
            VolumeOfExportsOfGoodsAndServices = new HashSet<VolumeOfExportsOfGoodsAndService>();
            VolumeOfImportsOfGoodsAndServices = new HashSet<VolumeOfImportsOfGoodsAndService>();
            WorldGDPPriceFixeds = new HashSet<WorldGDPPriceFixed>();
            YearlyValueTradeds = new HashSet<YearlyValueTraded>();
            OilProductionCountry2 = new HashSet<OilProductionCountry2>();
        }

        public int YearId { get; set; }

        public short? YearN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity_Year> Activity_Year { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bank_Year> Bank_Year { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrentAccountBalance> CurrentAccountBalances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceIndexValue> FinanceIndexValues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasConsumptionCountry> GasConsumptionCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasConsumptionRegion> GasConsumptionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasProductionCountry> GasProductionCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasProductionRegion> GasProductionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasReservedCountry> GasReservedCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GasReservedRegion> GasReservedRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsExportVolume> GoodsExportVolumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsImportVolume> GoodsImportVolumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketAnalyse> MarketAnalyses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiseryIndex> MiseryIndexes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilConsumptionCountry> OilConsumptionCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilConsumptionRegion> OilConsumptionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilProductionCountry> OilProductionCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilProductionRegion> OilProductionRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilReservedCountry> OilReservedCountries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilReservedRegion> OilReservedRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolumeOfExportsOfGoodsAndService> VolumeOfExportsOfGoodsAndServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolumeOfImportsOfGoodsAndService> VolumeOfImportsOfGoodsAndServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorldGDPPriceFixed> WorldGDPPriceFixeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YearlyValueTraded> YearlyValueTradeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OilProductionCountry2> OilProductionCountry2 { get; set; }
    }
}

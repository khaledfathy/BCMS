namespace BCMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BorsaCapitalDataModel : DbContext
    {
        public BorsaCapitalDataModel()
            : base("name=BorsaCapitalDataModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Activity_Year> Activity_Year { get; set; }
        public virtual DbSet<Advice> Advices { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Bank_Year> Bank_Year { get; set; }
        public virtual DbSet<Chart> Charts { get; set; }
        public virtual DbSet<ChartAnalysesKind> ChartAnalysesKinds { get; set; }
        public virtual DbSet<ChartCategory> ChartCategories { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfoes { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Country_CreditRatingAgency> Country_CreditRatingAgency { get; set; }
        public virtual DbSet<Country_Market> Country_Market { get; set; }
        public virtual DbSet<CridetRatingAgency> CridetRatingAgencies { get; set; }
        public virtual DbSet<CurrentAccountBalance> CurrentAccountBalances { get; set; }
        public virtual DbSet<Elder> Elders { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<ExamAnswer_question> ExamAnswer_question { get; set; }
        public virtual DbSet<ExamCategory> ExamCategories { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<ExamResult> ExamResults { get; set; }
        public virtual DbSet<ExamSubCategory> ExamSubCategories { get; set; }
        public virtual DbSet<ExamTrueOrFalse> ExamTrueOrFalses { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FinanceIndex> FinanceIndexes { get; set; }
        public virtual DbSet<FinanceIndexValue> FinanceIndexValues { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GasConsumptionCountry> GasConsumptionCountries { get; set; }
        public virtual DbSet<GasConsumptionRegion> GasConsumptionRegions { get; set; }
        public virtual DbSet<GasProductionCountry> GasProductionCountries { get; set; }
        public virtual DbSet<GasProductionRegion> GasProductionRegions { get; set; }
        public virtual DbSet<GasReservedCountry> GasReservedCountries { get; set; }
        public virtual DbSet<GasReservedRegion> GasReservedRegions { get; set; }
        public virtual DbSet<GoodsExportVolume> GoodsExportVolumes { get; set; }
        public virtual DbSet<GoodsImportVolume> GoodsImportVolumes { get; set; }
        public virtual DbSet<Indecator> Indecators { get; set; }
        public virtual DbSet<Information> Information { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Job_Education> Job_Education { get; set; }
        public virtual DbSet<Job_Prefer> Job_Prefer { get; set; }
        public virtual DbSet<Job_Skill> Job_Skill { get; set; }
        public virtual DbSet<Job_Specification> Job_Specification { get; set; }
        public virtual DbSet<Knowledge> Knowledges { get; set; }
        public virtual DbSet<Market> Markets { get; set; }
        public virtual DbSet<MarketAnalyse> MarketAnalyses { get; set; }
        public virtual DbSet<MarketType> MarketTypes { get; set; }
        public virtual DbSet<MarketValue> MarketValues { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MiseryIndex> MiseryIndexes { get; set; }
        public virtual DbSet<OilConsumptionCountry> OilConsumptionCountries { get; set; }
        public virtual DbSet<OilConsumptionRegion> OilConsumptionRegions { get; set; }
        public virtual DbSet<OilProductionCountry> OilProductionCountries { get; set; }
        public virtual DbSet<OilProductionRegion> OilProductionRegions { get; set; }
        public virtual DbSet<OilReservedCountry> OilReservedCountries { get; set; }
        public virtual DbSet<OilReservedRegion> OilReservedRegions { get; set; }
        public virtual DbSet<OtherOilConsumptionRegion> OtherOilConsumptionRegions { get; set; }
        public virtual DbSet<OtherOilProductionRegion> OtherOilProductionRegions { get; set; }
        public virtual DbSet<OtherOilReservedRegion> OtherOilReservedRegions { get; set; }
        public virtual DbSet<QuarterMarketValue> QuarterMarketValues { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RelativeSize> RelativeSizes { get; set; }
        public virtual DbSet<RelaxationVideo> RelaxationVideos { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<subject> subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tadawel> Tadawels { get; set; }
        public virtual DbSet<TadSheet> TadSheets { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Unity> Unities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VolumeOfExportsOfGoodsAndService> VolumeOfExportsOfGoodsAndServices { get; set; }
        public virtual DbSet<VolumeOfImportsOfGoodsAndService> VolumeOfImportsOfGoodsAndServices { get; set; }
        public virtual DbSet<WiseSaying> WiseSayings { get; set; }
        public virtual DbSet<WorldGDPPriceFixed> WorldGDPPriceFixeds { get; set; }
        public virtual DbSet<YearlyValueTraded> YearlyValueTradeds { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<OilProductionCountry2> OilProductionCountry2 { get; set; }
        public virtual DbSet<Region_CreditRatingAgency> Region_CreditRatingAgency { get; set; }
        public virtual DbSet<Petrochemical> Petrochemical { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.ActivityEngName)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.Activity_Year)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity_Year>()
                .Property(e => e.ActivityValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<Activity_Year>()
                .Property(e => e.CurrentActivityValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<Bank>()
                .Property(e => e.BankEnName)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.Bank_Year)
                .WithRequired(e => e.Bank)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bank_Year>()
                .Property(e => e.PercentageGrowthBranchsBank)
                .HasPrecision(6, 4);

            modelBuilder.Entity<Bank_Year>()
                .Property(e => e.PercentageGrowthATMMachine)
                .HasPrecision(6, 4);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Country_CreditRatingAgency)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Regions)
                .WithMany(e => e.Countries)
                .Map(m => m.ToTable("Region_Country").MapLeftKey("CountryId").MapRightKey("RegionId"));

            modelBuilder.Entity<Country_CreditRatingAgency>()
                .Property(e => e.Evaluation)
                .IsUnicode(false);

            modelBuilder.Entity<CridetRatingAgency>()
                .HasMany(e => e.Country_CreditRatingAgency)
                .WithRequired(e => e.CridetRatingAgency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CridetRatingAgency>()
                .HasMany(e => e.Region_CreditRatingAgency)
                .WithRequired(e => e.CridetRatingAgency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CurrentAccountBalance>()
                .Property(e => e.Value)
                .HasPrecision(6, 3);

            modelBuilder.Entity<CurrentAccountBalance>()
                .Property(e => e.ValuePercentage)
                .HasPrecision(5, 3);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.EvaluationText)
                .IsUnicode(false);

            modelBuilder.Entity<ExamCategory>()
                .HasMany(e => e.ExamSubCategories)
                .WithOptional(e => e.ExamCategory)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<ExamQuestion>()
                .HasMany(e => e.ExamAnswer_question)
                .WithOptional(e => e.ExamQuestion)
                .HasForeignKey(e => e.ques_id);

            modelBuilder.Entity<ExamSubCategory>()
                .HasMany(e => e.ExamQuestions)
                .WithOptional(e => e.ExamSubCategory)
                .HasForeignKey(e => e.subcategory_id);

            modelBuilder.Entity<ExamSubCategory>()
                .HasMany(e => e.ExamResults)
                .WithOptional(e => e.ExamSubCategory)
                .HasForeignKey(e => e.subcategory_id);

            modelBuilder.Entity<ExamTrueOrFalse>()
                .HasMany(e => e.ExamAnswer_question)
                .WithOptional(e => e.ExamTrueOrFalse)
                .HasForeignKey(e => e.is_right);

            modelBuilder.Entity<FinanceIndexValue>()
                .Property(e => e.IndexValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasConsumptionCountry>()
                .Property(e => e.GasConsumptionByBCM)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasConsumptionCountry>()
                .Property(e => e.GasConsumptionByBCF)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasConsumptionCountry>()
                .Property(e => e.GasConsumptionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasConsumptionRegion>()
                .Property(e => e.GasConsumptionByBCM)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasConsumptionRegion>()
                .Property(e => e.GasConsumptionByBCF)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasConsumptionRegion>()
                .Property(e => e.GasConsumptionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasProductionCountry>()
                .Property(e => e.GasProductionByBCM)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasProductionCountry>()
                .Property(e => e.GasProductionByBCF)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasProductionCountry>()
                .Property(e => e.GasProductionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasProductionRegion>()
                .Property(e => e.GasProductionByBCM)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasProductionRegion>()
                .Property(e => e.GasProductionByBCF)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasProductionRegion>()
                .Property(e => e.GasProductionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasReservedCountry>()
                .Property(e => e.GasReservesByCubicMetres)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasReservedCountry>()
                .Property(e => e.GasReservesByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasReservedRegion>()
                .Property(e => e.GasReservesByCubicMetres)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GasReservedRegion>()
                .Property(e => e.GasReservesByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<GoodsExportVolume>()
                .Property(e => e.Value)
                .HasPrecision(5, 3);

            modelBuilder.Entity<GoodsImportVolume>()
                .Property(e => e.Value)
                .HasPrecision(5, 3);

            modelBuilder.Entity<Knowledge>()
                .HasMany(e => e.Information)
                .WithRequired(e => e.Knowledge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.IssuedShares)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.FloatedShares)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.NetIncome)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.ShareHoldersEquity)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.MarketCap)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.EPS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.PE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.BookValue)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.PBV)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketAnalyse>()
                .Property(e => e.FloatedSharesMarketCap)
                .HasPrecision(8, 2);

            modelBuilder.Entity<MarketType>()
                .HasMany(e => e.MarketType1)
                .WithOptional(e => e.MarketType2)
                .HasForeignKey(e => e.ParentMarketTypeId);

            modelBuilder.Entity<MiseryIndex>()
                .Property(e => e.RateOfInflation)
                .HasPrecision(3, 1);

            modelBuilder.Entity<MiseryIndex>()
                .Property(e => e.UnemploymentRate)
                .HasPrecision(3, 1);

            modelBuilder.Entity<OilConsumptionCountry>()
                .Property(e => e.OilConsumptionByBarrel)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilConsumptionCountry>()
                .Property(e => e.OilConsumptionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilConsumptionRegion>()
                .Property(e => e.OilConsumptionByBarrel)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilConsumptionRegion>()
                .Property(e => e.OilConsumptionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilProductionCountry>()
                .Property(e => e.OilProductionByBarrel)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilProductionCountry>()
                .Property(e => e.OilProductionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilProductionRegion>()
                .Property(e => e.OilProductionByBarrel)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilProductionRegion>()
                .Property(e => e.OilProductionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilReservedCountry>()
                .Property(e => e.ProvedReservesBarrelValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilReservedCountry>()
                .Property(e => e.ProvedReservesTonlValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilReservedRegion>()
                .Property(e => e.ProvedReservesBarrelValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilReservedRegion>()
                .Property(e => e.ProvedReservesTonlValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OtherOilConsumptionRegion>()
                .Property(e => e.OilConsumptionBarrelValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OtherOilConsumptionRegion>()
                .Property(e => e.OilConsumptionTonneValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OtherOilProductionRegion>()
                .Property(e => e.OilProductionBarrelValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OtherOilProductionRegion>()
                .Property(e => e.OilProductionTonneValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OtherOilReservedRegion>()
                .Property(e => e.ProvedReservesBarrelValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OtherOilReservedRegion>()
                .Property(e => e.ProvedReservesTonlValue)
                .HasPrecision(8, 3);

            modelBuilder.Entity<QuarterMarketValue>()
                .Property(e => e.MarketValue)
                .HasPrecision(8, 2);

            modelBuilder.Entity<QuarterMarketValue>()
                .Property(e => e.ValueTradedOfStocks)
                .HasPrecision(8, 2);

            modelBuilder.Entity<QuarterMarketValue>()
                .Property(e => e.DailyAvaregeValueTraded)
                .HasPrecision(8, 2);

            modelBuilder.Entity<QuarterMarketValue>()
                .Property(e => e.NumberOfStockTraded)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Region_CreditRatingAgency)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RelativeSize>()
                .Property(e => e.Size)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.CompanyInfoes)
                .WithOptional(e => e.Sector)
                .HasForeignKey(e => e.SectorID);

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.MarketAnalyses)
                .WithOptional(e => e.Sector)
                .HasForeignKey(e => e.SectorId);

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Sector)
                .HasForeignKey(e => e.SectorId);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.TransactionValue)
                .HasPrecision(15, 3);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.TradedStock)
                .HasPrecision(15, 3);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.TradedStocksValue)
                .HasPrecision(15, 3);

            modelBuilder.Entity<VolumeOfExportsOfGoodsAndService>()
                .Property(e => e.Value)
                .HasPrecision(5, 3);

            modelBuilder.Entity<VolumeOfImportsOfGoodsAndService>()
                .Property(e => e.Value)
                .HasPrecision(5, 3);

            modelBuilder.Entity<WorldGDPPriceFixed>()
                .Property(e => e.Value)
                .HasPrecision(5, 3);

            modelBuilder.Entity<YearlyValueTraded>()
                .Property(e => e.ValueTraded)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Year>()
                .HasMany(e => e.Activity_Year)
                .WithRequired(e => e.Year)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Year>()
                .HasMany(e => e.Bank_Year)
                .WithRequired(e => e.Year)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OilProductionCountry2>()
                .Property(e => e.OilProductionByBarrel)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OilProductionCountry2>()
                .Property(e => e.OilProductionByTonne)
                .HasPrecision(8, 3);

            modelBuilder.Entity<Region_CreditRatingAgency>()
                .Property(e => e.Evaluation)
                .IsUnicode(false);
        }
    }
}

using BCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BCMS.Areas.UTMS.Models;
using System.Data.Entity;


namespace BCMS.Areas.UTMS.Controllers
{
    public class BorsaGraphicsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        public JsonResult GetAllChartCategories()
        {
            try
            {
                var model = DB.ChartCategories.Select(c => new { c.ChartCategoryId, c.ChartCategoryName, c.Description }).ToList();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult GetAllChartAnalysesKind(int id)
        {
            try
            {
                DB.Configuration.ProxyCreationEnabled = false;
                var Charts = DB.ChartAnalysesKinds.Where(a => a.ChartCategoryId == id).Include(a => a.Charts).Select(z => new { z.CAKId, z.CAKName, z.Charts }).ToList();
                return Json(Charts, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult GetAllCharts(int id)
        {
            try
            {
                var model = DB.Charts.Where(w => w.CAKId == id).Select(c => new { c.ChartId, c.ChartName, c.ChartAnalysesKind.CAKName, c.ChartAnalysesKind.ChartCategory.ChartCategoryName, c.ChartAnalysesKind.ChartCategoryId }).ToList();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
        }


        public ActionResult ChartDiv(int id)
        {
            try
            {
                var model = DB.Charts.FirstOrDefault(w => w.ChartId == id);
                return View(model);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        #region التقييم الإتماني
        [HttpPost]
        public JsonResult CreditRatings(string agency, string regionId)//التقييم الإتمانى
        {
            int Agency = Convert.ToInt32(agency), RegionID = Convert.ToInt32(regionId);
            var result = (from b in DB.Country_CreditRatingAgency
                          where b.Year == 2014 && b.AgencyId == Agency && b.PeriodId == 4 &&
                          b.Country.Regions.Where(r => r.RegionId == RegionID).Count() > 0
                          select new
                          {
                              country = b.Country.CountryArName+","+ b.Excpectation,
                              excepctation = b.Excpectation,
                              value = (b.AsumptionValue) * 10
                          }

                            ).OrderByDescending(o => o.value);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult selectAllRegion()
        {
            var result = (from b in DB.Regions
                          select new
                          {
                              RegionId = b.RegionId,
                              RegionName = b.RegionArName
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        public JsonResult _Partial1Data()// معدل القيمة المتداولة
        {
            try
            {


                var result = (from b in DB.QuarterMarketValues
                              select new
                              {
                                  Market = b.Market.MarketArName,
                                  MarketValue = b.DailyAvaregeValueTraded
                              }).OrderByDescending(a => a.MarketValue);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial2Data()//القيمة السوقية للإسواق العربية
        {
            try
            {


                var result = (from b in DB.QuarterMarketValues

                              select new
                              {
                                  Market = b.Market.MarketArName,
                                  MarketValue = b.MarketValue
                              }).OrderByDescending(a => a.MarketValue);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial5Data()//الحجم النسبي للقيمة السوقية للأسواق العربية
        {
            try
            {


                var Total = DB.QuarterMarketValues.Sum(s => s.MarketValue);
                var result = (from b in DB.QuarterMarketValues

                              select new
                              {
                                  Market = b.Market.MarketArName,

                                  AverageValue = (b.MarketValue / Total) * 100

                              }).OrderByDescending(a => a.AverageValue);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial6Data()//قيمة الاسهم المتادولة للاسواق العربية
        {
            try
            {


                var result = (from b in DB.QuarterMarketValues

                              select new
                              {

                                  Market = b.Market.MarketArName,
                                  ValueTradedOfStock = b.ValueTradedOfStocks
                              }).OrderByDescending(a => a.ValueTradedOfStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial7Data()//عدد الاسهم المتادولة للاسواق العربية
        {
            try
            {


                var result = (from b in DB.QuarterMarketValues

                              select new
                              {

                                  Market = b.Market.MarketArName,
                                  NumberTradedOfStock = b.NumberOfStockTraded
                              }).OrderByDescending(a => a.NumberTradedOfStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial8Data()//المعدل اليومي لعدد الأسهم المتداولة للأسواق العربية
        {
            try
            {


                var result = (from b in DB.QuarterMarketValues

                              select new
                              {

                                  Market = b.Market.MarketArName,
                                  DailyNumberTradedOfStock = b.DailyAverageOfStockTraded
                              }).OrderByDescending(a => a.DailyNumberTradedOfStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial9Data()//عدد الشركات المدرجة بالأسواق العربية
        {
            try
            {


                var result = (from b in DB.QuarterMarketValues
                              select new
                              {
                                  Market = b.Market.MarketArName,
                                  NumberOFlistedCompany = b.NumberOfListedCompanies
                              }).OrderByDescending(a => a.NumberOFlistedCompany);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }


        }

        public JsonResult _Partial10Data()//نسبة قيمة الواردات من السلع والخدمات
        {
            try
            {


                var result = (from b in DB.VolumeOfImportsOfGoodsAndServices
                                  //where b.Market.Country.Regions.Where(r => r.RegionId == 15).Count() > 0
                              where b.YearId == 55//2014
                              select new
                              {
                                  CountryName = b.Country.CountryArName,
                                  VolueOfImports = b.Value
                              }).OrderByDescending(a => a.VolueOfImports);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial11Data()//توقعات نسبة حجم الواردات من السلع والخدمات لدول ( العالم - العربية - الخليجية ) 2019
        {
            try
            {


                var result = (from b in DB.VolumeOfImportsOfGoodsAndServices

                              where b.YearId == 60//2019
                              select new
                              {
                                  CountryName = b.Country.CountryArName,
                                  VolueOfImports = b.Value
                              }).OrderByDescending(a => a.VolueOfImports);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult _Partial12Data(string CountryName)//نسبة حجم الواردات من السلع والخدمات السعودية ( كل دولة على حدى)  2012 -  2019
        {
            try
            {


                var result = (from b in DB.VolumeOfImportsOfGoodsAndServices

                              where b.Country.CountryArName == CountryName && b.YearId >= 18
                              select new
                              {
                                  YearName = b.Year.YearN,
                                  VolueOfImports = b.Value
                              }).OrderBy(a => a.YearName);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetAllCountries()
        {
            try
            {


                var countrylist = DB.Countries.Select(x => x.CountryArName).ToList();
                return Json(countrylist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        //===========================================================================

        public JsonResult GDPWithStaticPrice()//بالاسعر الثابتة GDP
        {
            try
            {


                var result = (from b in DB.Activity_Year
                              join o in DB.Years on b.YearId equals o.YearId
                              group b by new { b.YearId, b.Year.YearN } into g
                              select new
                              {
                                  yName = g.Select(o => o.Year.YearN).FirstOrDefault(),
                                  pValue = g.Sum(o => o.ActivityValue)
                              }
                              );
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GDPWithCurrentPrice()//بالاسعار الجارية GDP
        {
            try
            {


                var result = (from b in DB.Activity_Year
                              join o in DB.Years on b.YearId equals o.YearId
                              group b by new { b.YearId, b.Year.YearN } into g
                              select new
                              {
                                  yName = g.Select(o => o.Year.YearN).FirstOrDefault(),
                                  pValue = g.Sum(o => o.CurrentActivityValue)
                              }
                             );
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GDPByActivity()//بحسب النشاط GDP
        {
            try
            {


                //int m = DB.Years.Max(a => a.YearId);
                int m = 54;
                var result = (from b in DB.Activity_Year
                              where b.YearId == m && b.Activity.ActivityId != 12 && b.Activity.ActivityId != 11
                              select new
                              {
                                  bName = b.Activity.ActivityArName,
                                  bValue = b.ActivityValue
                              }).OrderByDescending(a => a.bValue);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        //===========================================================================

        public JsonResult MiseryIndex()//مؤشر البؤس
        {
            try
            {


                var result = (from b in DB.MiseryIndexes
                              select new
                              {
                                  YearName = b.Year.YearN,
                                  MisryIndex = (b.RateOfInflation + b.UnemploymentRate)
                              }).OrderBy(a => a.YearName);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //===========================================================================

        public JsonResult FreeStock()//الأسهم الحرة لقطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses

                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  FreeStock = b.FloatedShares
                              }).OrderByDescending(a => a.FreeStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ThePercentageOfFreeShares()//نسبة الأسهم الحرة لقطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses

                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  AvgFreeStock = ((b.FloatedShares) / (b.IssuedShares)) * 100
                              }).OrderByDescending(a => a.AvgFreeStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult MarketValue()//القيمة السوقية للأسهم الحرة لقطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses

                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  FreeStock = b.FloatedSharesMarketCap
                              }).OrderByDescending(a => a.FreeStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult TheImpactOfFreeStock()//نسبة تأثير الأسهم الحرة للقطاعات على مؤشر السوق المالية السعودية
        {
            try
            {
                var total = DB.MarketAnalyses.Sum(s => s.FloatedSharesMarketCap);
                var result = (from b in DB.MarketAnalyses

                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  AvgFreeStock = (b.FloatedSharesMarketCap / total) * 100
                              }).OrderByDescending(a => a.AvgFreeStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        //===========================================================================

        public JsonResult SectorsDeals() //صفقات القطاعات في السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.Transactions
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  TransactionValue = b.TransactionValue
                              }).OrderByDescending(a => a.TransactionValue);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult PercentageOfDeals()//نسبة صفقات القطاعات في السوق المالية السعودية
        {
            try
            {
                var total = DB.Transactions.Sum(s => s.TransactionValue);
                var result = (from b in DB.Transactions
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  AvgTransactionValue = (b.TransactionValue / total) * 100
                              }).OrderByDescending(a => a.AvgTransactionValue);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult SharesTraded()//الاسهم المتداولة في قطاعات المالية السعودية
        {
            try
            {
                var result = (from b in DB.Transactions
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  TradedStock = b.TradedStock
                              }).OrderByDescending(a => a.TradedStock);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult PercentageOfTradedShares()//نسبة الاسهم المتداولة في قطاعات المالية السعودية
        {
            try
            {
                var total = DB.Transactions.Sum(s => s.TradedStock);
                var result = (from b in DB.Transactions
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  AvgTradedStocks = (b.TradedStock / total) * 100
                              }).OrderByDescending(a => a.AvgTradedStocks);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ValueOfSharesTraded()//قيمة الأسهم المتداولة فى قطاعات السوق المالية السعودية  شهر نوفمبر 2014
        {
            try
            {
                var result = (from b in DB.Transactions
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  TradedStocksValue = b.TradedStocksValue
                              }).OrderByDescending(a => a.TradedStocksValue);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult PercentageOfTheValueOfShares()//نسبة قيمة الأسهم المتداولة فى قطاعات السوق المالية السعودية  شهر نوفمبر 2014
        {
            try
            {
                var total = DB.Transactions.Sum(s => s.TradedStocksValue);
                var result = (from b in DB.Transactions
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  AvgTradedStocksValue = (b.TradedStocksValue / total) * 100
                              }).OrderByDescending(a => a.AvgTradedStocksValue);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult BankBranches(int? bankCode)//فروع المصارف
        {
            try
            {
                //int m = DB.Years.Max(a => a.YearId);
                var result = (from b in DB.Bank_Year
                              where b.Bank.BankCode == bankCode
                              select new
                              {
                                  bYear = b.Year.YearN,
                                  bCount = b.BranchsBank,
                                  bName = b.Bank.BankArName
                              });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult GetAllBanks()
        {
            try
            {
                var Data = DB.Banks.Select(s => new { s.BankCode, s.BankArName }).ToList();
                return Json(Data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult Basic_ColumnData()
        {
            try
            {
                int m = 20;
                var result = (from b in DB.Bank_Year
                              where b.YearId == m
                              select new
                              {
                                  bName = b.Bank.BankArName,
                                  bCount = b.BranchsBank
                              }).OrderByDescending(a => a.bCount);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        //===========================================================================

        public JsonResult NetIncome()//صافي الدخل لقطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses

                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  netIncome = b.NetIncome
                              }).OrderByDescending(a => a.netIncome);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ShareholdersEquity() //حقوق المساهمين لقطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses

                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  shareHolders = b.ShareHoldersEquity
                              }).OrderByDescending(a => a.shareHolders);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ReturnOnRights() //العائد علي حقوق المساهمين لقطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses

                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  ROE = (b.NetIncome / b.ShareHoldersEquity) * 100
                              }).OrderByDescending(a => a.ROE);

                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult  PercentageOfMarketValue()//نسبة قطاعات السوق المالية السعودية للقيمه السوقيه
        {
            try
            {


                var total = DB.MarketAnalyses.Sum(s => s.MarketCap);
                var result = (from b in DB.MarketAnalyses
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  AvgMarketCap = (b.MarketCap / total) * 100
                              }).OrderByDescending(a => a.AvgMarketCap);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult TheYieldOnStocks() //العائد لأسهم قطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  EPS = b.EPS
                              }).OrderByDescending(a => a.EPS);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SharePriceReturn()//السعر للعائد لأسهم قطاعات السوق المالية السعودية
        {
            try
            {


                var result = (from b in DB.MarketAnalyses
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  PE = b.PE
                              }).OrderByDescending(a => a.PE);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BookValue()//القيمة الدفترية لأسهم قطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  BookValue = b.BookValue
                              }).OrderByDescending(a => a.BookValue);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BookValuePrice()//السعر للقيمة الدفترية لأسهم قطاعات السوق المالية السعودية
        {
            try
            {
                var result = (from b in DB.MarketAnalyses
                              select new
                              {
                                  Sectors = b.Sector.SectorName,
                                  PBV = b.PBV
                              }).OrderByDescending(a => a.PBV);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //============================================================================
        #region Oil
        
        #region احتياطي النفط
     
        //الاحتياطي المؤكد للنفط علي مستوى العالم بالبرميل
        [HttpGet]
        public JsonResult _Partial1Data1()
        {
            try
            {
                var data = from s in DB.OilReservedRegions
                           where (s.YearId == 34 || s.YearId == 44 || s.YearId == 53 || s.YearId == 54)
                           group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //  الاحتياطي المؤكد للنفط حسب المناطق علي مستوى العالم بالبرميل
        [HttpGet]
        public JsonResult _Partial2Data1()
        {
            try
            {
                #region Another Way
                /*
                List<OilItem> arr = new List<OilItem>();
                arr.Add(new OilItem()
                {
                    RegionArName = DB.OilReservedRegions.Where(s => s.RegionId == 20).Select(s => s.Region.RegionArName).FirstOrDefault(),
                    Value = DB.OilReservedRegions.Where(s => s.RegionId == 20 && s.YearId==54).Select(s => s.ProvedReservesBarrelValue).Sum(),
                });
                arr.Add(new OilItem()
                {
                    RegionArName = DB.OilReservedRegions.Where(s => s.RegionId == 18).Select(s => s.Region.RegionArName).FirstOrDefault(),
                    Value = DB.OilReservedRegions.Where(s => s.RegionId == 18 && s.YearId == 54).Select(s => s.ProvedReservesBarrelValue).Sum(),
                });
                arr.Add(new OilItem()
                {
                    RegionArName = DB.OilReservedRegions.Where(s => s.RegionId == 17).Select(s => s.Region.RegionArName).FirstOrDefault(),
                    Value = DB.OilReservedRegions.Where(s => s.RegionId == 17 && s.YearId == 54).Select(s => s.ProvedReservesBarrelValue).Sum(),
                });
                arr.Add(new OilItem()
                {
                    RegionArName = DB.OilReservedRegions.Where(s => s.RegionId == 19).Select(s => s.Region.RegionArName).FirstOrDefault(),
                    Value = DB.OilReservedRegions.Where(s => s.RegionId == 19 && s.YearId == 54).Select(s => s.ProvedReservesBarrelValue).Sum(),
                });
                arr.Add(new OilItem()
                {
                    RegionArName = DB.OilReservedRegions.Where(s => s.RegionId == 21).Select(s => s.Region.RegionArName).FirstOrDefault(),
                    Value = DB.OilReservedRegions.Where(s => s.RegionId == 21 && s.YearId == 54).Select(s => s.ProvedReservesBarrelValue).Sum(),
                });
                arr.Add(new OilItem()
                {
                    RegionArName = DB.OilReservedRegions.Where(s => s.RegionId ==22).Select(s => s.Region.RegionArName).FirstOrDefault(),
                    Value = DB.OilReservedRegions.Where(s => s.RegionId == 22 && s.YearId == 54).Select(s => s.ProvedReservesBarrelValue).Sum(),
                });
                 var result = from p in arr select new { p.RegionArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
                */
                #endregion

                var data = (from s in DB.OilReservedRegions
                            where (s.YearId == 54 && s.RegionId == 20) || (s.YearId == 54 && s.RegionId == 18) || (s.YearId == 54 && s.RegionId == 17) || (s.YearId == 54 && s.RegionId == 19) || (s.YearId == 54 && s.RegionId == 21) || (s.YearId == 54 && s.RegionId == 22)
                            group s.ProvedReservesBarrelValue by s.Region.RegionArName into mygroup
                            select new OilItem
                            {
                                RegionArName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            }).OrderByDescending(o => o.Value);


                var result = from p in data select new { p.RegionArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //الاحتياطي المؤكد للنفط حسب المناطق علي مستوى العالم بالطن
        [HttpGet]
        public JsonResult RegionProvedReservesTonlValues()
        {
            try
            {
                var data = from s in DB.OilReservedRegions
                           where (s.YearId == 54 && s.RegionId == 20) || (s.YearId == 54 && s.RegionId == 18) || (s.YearId == 54 && s.RegionId == 17) || (s.YearId == 54 && s.RegionId == 19) || (s.YearId == 54 && s.RegionId == 21) || (s.YearId == 54 && s.RegionId == 22)
                           group s.ProvedReservesTonlValue by s.Region.RegionArName into mygroup
                           select new OilItem
                           {
                               RegionArName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.RegionArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //الاحتياطي المؤكد للنفط حسب الاوبك بالبرميل
        public ActionResult _Partial3Data1()
        {
            try
            {


                var data = from s in DB.OilReservedRegions
                           where (s.YearId == 34 && s.RegionId == 24) || (s.YearId == 44 && s.RegionId == 24) || (s.YearId == 53 && s.RegionId == 24) || (s.YearId == 54 && s.RegionId == 24)
                           group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //الاحتياطي المؤكد للنفط للدول خارج الاوبك بالبرميل
        public ActionResult _Partial4Data1()
        {
            try
            {
                var data = from s in DB.OilReservedRegions
                           where (s.YearId == 34 && s.RegionId == 25) || (s.YearId == 44 && s.RegionId == 25) || (s.YearId == 53 && s.RegionId == 25) || (s.YearId == 54 && s.RegionId == 25)
                           group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // بالبرميل (OECD) الاحتياطي المؤكد للنفط حسب
        public ActionResult _Partial5Data1()
        {
            try
            {
                var data = from s in DB.OilReservedRegions
                           where (s.YearId == 34 && s.RegionId == 23) || (s.YearId == 44 && s.RegionId == 23) || (s.YearId == 53 && s.RegionId == 23) || (s.YearId == 54 && s.RegionId == 23)
                           group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // بالبرميل(OECD) الاحتياطي المؤكد للنفط لغير
        public ActionResult _Partial6Data1()
        {
            try
            {


                var data = from s in DB.OilReservedRegions
                           where (s.YearId == 34 && s.RegionId == 26) || (s.YearId == 44 && s.RegionId == 26) || (s.YearId == 53 && s.RegionId == 26) || (s.YearId == 54 && s.RegionId == 26)
                           group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //الإحتياطى المؤكد للنفط حسب الدولة بالبرميل  2013  		
        public ActionResult _Partial7Data1()
        {
            try
            {
                var data = (from s in DB.OilReservedCountries
                            where
                              (s.YearId == 54 && s.CountryId == 31)
                            || (s.YearId == 54 && s.CountryId == 80)
                            || (s.YearId == 54 && s.CountryId == 150)
                            || (s.YearId == 54 && s.CountryId == 92)
                            || (s.YearId == 54 && s.CountryId == 188)
                            || (s.YearId == 54 && s.CountryId == 181)
                            || (s.YearId == 54 && s.CountryId == 142)
                            || (s.YearId == 54 && s.CountryId == 183)
                            || (s.YearId == 54 && s.CountryId == 128)
                            || (s.YearId == 54 && s.CountryId == 87)
                            || (s.YearId == 54 && s.CountryId == 140)
                            || (s.YearId == 54 && s.CountryId == 36)
                            || (s.YearId == 54 && s.CountryId == 24)
                            select new OilItem
                            {
                                CountryArName = s.Country.CountryArName,
                                Value = s.ProvedReservesBarrelValue
                            }).OrderByDescending(s => s.Value);
                var result = from p in data select new { p.CountryArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //اكبر خمس احتياطي مؤكد للنفط 1993-2013
        public ActionResult _Partial8Data1()
        {
            try
            {
                //Saudi Arabia
                var data1 = (from s in DB.OilReservedCountries
                             where (s.YearId == 34 && s.CountryId == 150) || (s.YearId == 44 && s.CountryId == 150) || (s.YearId == 53 && s.CountryId == 150) || (s.YearId == 54 && s.CountryId == 150)
                             group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });//.OrderByDescending(s => s.Value);


                var result1 = from p in data1 select new { p.YearName, p.Value };

                //Vanzoila
                var data2 = (from s in DB.OilReservedCountries
                             where (s.YearId == 34 && s.CountryId == 188) || (s.YearId == 44 && s.CountryId == 188) || (s.YearId == 53 && s.CountryId == 188) || (s.YearId == 54 && s.CountryId == 188)
                             group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });//.OrderByDescending(s=>s.Value);


                var result2 = from p in data2 select new { p.YearName, p.Value };

                //Canada
                var data3 = (from s in DB.OilReservedCountries
                             where (s.YearId == 34 && s.CountryId == 31) || (s.YearId == 44 && s.CountryId == 31) || (s.YearId == 53 && s.CountryId == 31) || (s.YearId == 54 && s.CountryId == 31)
                             group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });//.OrderByDescending(s=>s.Value);


                var result3 = from p in data3 select new { p.YearName, p.Value };

                //Iraq
                var data4 = (from s in DB.OilReservedCountries
                             where (s.YearId == 34 && s.CountryId == 80) || (s.YearId == 44 && s.CountryId == 80) || (s.YearId == 53 && s.CountryId == 80) || (s.YearId == 54 && s.CountryId == 80)
                             group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });//.OrderByDescending(s=>s.Value);


                var result4 = from p in data4 select new { p.YearName, p.Value };

                //Kwiat
                var data5 = (from s in DB.OilReservedCountries
                             where (s.YearId == 34 && s.CountryId == 92) || (s.YearId == 44 && s.CountryId == 92) || (s.YearId == 53 && s.CountryId == 92) || (s.YearId == 54 && s.CountryId == 92)
                             group s.ProvedReservesBarrelValue by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });//.OrderByDescending(s=>s.Value);


                var result5 = from p in data5 select new { p.YearName, p.Value };


                return Json(new { FirstList = result1, SecondList = result2, ThirdList = result3, FourthList = result4, FivethList = result5 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region انتاج النفط
        //انتاج العالم للنفط من 65-2013 بالبرميل
        public ActionResult _Partial9Data1()
        {
            try
            {
                var data = from s in DB.OilProductionCountries
                           where (
                             s.YearId == 6
                           || s.YearId == 16
                           || s.YearId == 26
                           || s.YearId == 36
                           || s.YearId == 46
                           || s.YearId == 54
                           )
                           group s.OilProductionByBarrel by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج العالم للنفط من 65-2013 بالطن
        public ActionResult _Partial10Data1()
        {
            try
            {
                var data = from s in DB.OilProductionCountries
                           where (
                             s.YearId == 6
                           || s.YearId == 16
                           || s.YearId == 26
                           || s.YearId == 36
                           || s.YearId == 46
                           || s.YearId == 54
                           )
                           group s.OilProductionByTonne by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج العالم للنفط من 2013-65 بالبرميل حسب المناطق
        public ActionResult _Partial11Data1()
        {
            try
            {
                /////////////////////////
                var data1 = (from s in DB.OilProductionRegions
                             where
                                 (s.YearId == 6 && s.RegionId == 20)
                              || (s.YearId == 16 && s.RegionId == 20)
                              || (s.YearId == 26 && s.RegionId == 20)
                              || (s.YearId == 36 && s.RegionId == 20)
                              || (s.YearId == 46 && s.RegionId == 20)
                              || (s.YearId == 54 && s.RegionId == 20)
                             group s.OilProductionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             }).OrderByDescending(s => s.Value);


                var result1 = from p in data1 select new { p.YearName, p.Value };


                var data2 = (from s in DB.OilProductionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 18)
                             || (s.YearId == 16 && s.RegionId == 18)
                             || (s.YearId == 26 && s.RegionId == 18)
                             || (s.YearId == 36 && s.RegionId == 18)
                             || (s.YearId == 46 && s.RegionId == 18)
                             || (s.YearId == 54 && s.RegionId == 18)
                             group s.OilProductionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result2 = from p in data2 select new { p.YearName, p.Value };
                var data3 = (from s in DB.OilProductionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 17)
                             || (s.YearId == 16 && s.RegionId == 17)
                             || (s.YearId == 26 && s.RegionId == 17)
                             || (s.YearId == 36 && s.RegionId == 17)
                             || (s.YearId == 46 && s.RegionId == 17)
                             || (s.YearId == 54 && s.RegionId == 17)
                             group s.OilProductionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result3 = from p in data3 select new { p.YearName, p.Value };
                var data4 = (from s in DB.OilProductionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 19)
                             || (s.YearId == 16 && s.RegionId == 19)
                             || (s.YearId == 26 && s.RegionId == 19)
                             || (s.YearId == 36 && s.RegionId == 19)
                             || (s.YearId == 46 && s.RegionId == 19)
                             || (s.YearId == 54 && s.RegionId == 19)
                             group s.OilProductionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result4 = from p in data4 select new { p.YearName, p.Value };
                var data5 = (from s in DB.OilProductionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 21)
                             || (s.YearId == 16 && s.RegionId == 21)
                             || (s.YearId == 26 && s.RegionId == 21)
                             || (s.YearId == 36 && s.RegionId == 21)
                             || (s.YearId == 46 && s.RegionId == 21)
                             || (s.YearId == 54 && s.RegionId == 21)
                             group s.OilProductionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result5 = from p in data5 select new { p.YearName, p.Value };
                var data6 = (from s in DB.OilProductionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 22)
                             || (s.YearId == 16 && s.RegionId == 22)
                             || (s.YearId == 26 && s.RegionId == 22)
                             || (s.YearId == 36 && s.RegionId == 22)
                             || (s.YearId == 46 && s.RegionId == 22)
                             || (s.YearId == 54 && s.RegionId == 22)
                             group s.OilProductionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result6 = from p in data6 select new { p.YearName, p.Value };
                return Json(new { FirstList = result1, SecondList = result2, ThirdList = result3, FourthList = result4, FivethList = result5, SixList = result6 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج العالم للنفط  2013 بالبرميل حسب المناطق
        public ActionResult _Partial12Data1()
        {
            try
            {
                var data = (from s in DB.OilProductionRegions
                            where
                               (s.YearId == 54 && s.RegionId == 20)
                            || (s.YearId == 54 && s.RegionId == 18)
                            || (s.YearId == 54 && s.RegionId == 17)
                            || (s.YearId == 54 && s.RegionId == 19)
                            || (s.YearId == 54 && s.RegionId == 21)
                            || (s.YearId == 54 && s.RegionId == 22)
                            group s.OilProductionByBarrel by s.Region.RegionArName into mygroup
                            select new OilItem
                            {
                                RegionArName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            }).OrderByDescending(s => s.Value);


                var result = from p in data select new { p.RegionArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج العالم للنفط  2013 بالطن حسب المناطق
        public ActionResult _Partial13Data1()
        {
            try
            {
                var data = (from s in DB.OilProductionRegions
                            where
                               (s.YearId == 54 && s.RegionId == 20)
                            || (s.YearId == 54 && s.RegionId == 18)
                            || (s.YearId == 54 && s.RegionId == 17)
                            || (s.YearId == 54 && s.RegionId == 19)
                            || (s.YearId == 54 && s.RegionId == 21)
                            || (s.YearId == 54 && s.RegionId == 22)
                            group s.OilProductionByTonne by s.Region.RegionArName into mygroup
                            select new OilItem
                            {
                                RegionArName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            }).OrderByDescending(s => s.Value);


                var result = from p in data select new { p.RegionArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج العالم للنفط من 65-2013 بالطن حسب المناطق
        public ActionResult _Partial14Data1()
        {
            try
            {
                //الشرق الاوسط
                var data1 = (from s in DB.OilProductionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 20)
                             || (s.YearId == 16 && s.RegionId == 20)
                             || (s.YearId == 26 && s.RegionId == 20)
                             || (s.YearId == 36 && s.RegionId == 20)
                             || (s.YearId == 46 && s.RegionId == 20)
                             || (s.YearId == 54 && s.RegionId == 20)
                             group s.OilProductionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result1 = from p in data1 select new { p.YearName, p.Value };

                //امريكا الوسطى
                var data2 = (from s in DB.OilProductionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 18)
                             || (s.YearId == 16 && s.RegionId == 18)
                             || (s.YearId == 26 && s.RegionId == 18)
                             || (s.YearId == 36 && s.RegionId == 18)
                             || (s.YearId == 46 && s.RegionId == 18)
                             || (s.YearId == 54 && s.RegionId == 18)
                             group s.OilProductionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });

                var result2 = from p in data2 select new { p.YearName, p.Value };
                //امريكا الشمالية
                var data3 = (from s in DB.OilProductionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 17)
                             || (s.YearId == 16 && s.RegionId == 17)
                             || (s.YearId == 26 && s.RegionId == 17)
                             || (s.YearId == 36 && s.RegionId == 17)
                             || (s.YearId == 46 && s.RegionId == 17)
                             || (s.YearId == 54 && s.RegionId == 17)
                             group s.OilProductionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result3 = from p in data3 select new { p.YearName, p.Value };

                //اوربا واوراسيا
                var data4 = (from s in DB.OilProductionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 19)
                             || (s.YearId == 16 && s.RegionId == 19)
                             || (s.YearId == 26 && s.RegionId == 19)
                             || (s.YearId == 36 && s.RegionId == 19)
                             || (s.YearId == 46 && s.RegionId == 19)
                             || (s.YearId == 54 && s.RegionId == 19)
                             group s.OilProductionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result4 = from p in data4 select new { p.YearName, p.Value };

                //افريقيا
                var data5 = (from s in DB.OilProductionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 21)
                             || (s.YearId == 16 && s.RegionId == 21)
                             || (s.YearId == 26 && s.RegionId == 21)
                             || (s.YearId == 36 && s.RegionId == 21)
                             || (s.YearId == 46 && s.RegionId == 21)
                             || (s.YearId == 54 && s.RegionId == 21)
                             group s.OilProductionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result5 = from p in data5 select new { p.YearName, p.Value };

                //اسيا والمحيط
                var data6 = (from s in DB.OilProductionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 22)
                             || (s.YearId == 16 && s.RegionId == 22)
                             || (s.YearId == 26 && s.RegionId == 22)
                             || (s.YearId == 36 && s.RegionId == 22)
                             || (s.YearId == 46 && s.RegionId == 22)
                             || (s.YearId == 54 && s.RegionId == 22)
                             group s.OilProductionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result6 = from p in data6 select new { p.YearName, p.Value };
                return Json(new { FirstList = result1, SecondList = result2, ThirdList = result3, FourthList = result4, FivethList = result5, SixList = result6 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //   بالبرميل(NON OECD , OECD) انتاج النفط حسب 
        public ActionResult _Partial15Data1()
        {
            try
            {
                //var data = from s in DB.OilProductionRegions
                //           where (s.YearId == 54 && s.RegionId == 23)
                //           group s.OilProductionByBarrel by s.Year.YearN into mygroup
                //           select new OilItem
                //           {
                //               YearName = mygroup.Key,
                //               Value = mygroup.Sum(i => i.Value)
                //           };


                //var result = from p in data select new { p.YearName, p.Value };
                //return Json(result, JsonRequestBehavior.AllowGet);

                var data1 = from s in DB.OilProductionRegions
                            where (s.YearId == 54 && s.RegionId == 23)
                            group s.OilProductionByBarrel by s.Region.RegionEnName into mygroup
                            select new OilItem
                            {
                                RegionEnName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            };


                var result1 = from p in data1 select new { p.RegionEnName, p.Value };

                var data2 = from s in DB.OilProductionRegions
                            where (s.YearId == 54 && s.RegionId == 26)
                            group s.OilProductionByBarrel by s.Region.RegionEnName into mygroup
                            select new OilItem
                            {
                                RegionEnName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            };


                var result2 = from p in data2 select new { p.RegionEnName, p.Value };


                return Json(new { FirstList = result1, SecondList = result2 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }







            /////////////////////////until test
        }

        //بالمليون طن (NON OECD),(OECD) انتاج النفط حسب  
        public ActionResult _Partial16Data1()
        {
            try
            {
                var data = from s in DB.OilProductionRegions
                           where (s.YearId == 54 && s.RegionId == 23)
                           || (s.YearId == 54 && s.RegionId == 26)

                           select new OilItem
                           {
                               RegionEnName = s.Region.RegionEnName,
                               Value = s.OilProductionByTonne.Value
                           };


                var result = from p in data select new { p.RegionEnName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج الشرق الأوسط للنفط 2013ألف برميل يوميا			
        public ActionResult _Partial17Data1()
        {
            try
            {


                var data = (from s in DB.OilProductionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId

                            where (s.YearId == 54 && c.CountryId == 79)
                            || (s.YearId == 54 && c.CountryId == 150)
                            || (s.YearId == 54 && c.CountryId == 92)
                            || (s.YearId == 54 && c.CountryId == 80)
                            || (s.YearId == 54 && c.CountryId == 140)
                            || (s.YearId == 54 && c.CountryId == 181)
                            || (s.YearId == 54 && c.CountryId == 13)
                            || (s.YearId == 54 && c.CountryId == 130)
                            || (s.YearId == 54 && c.CountryId == 168)
                            || (s.YearId == 54 && c.CountryId == 190)
                            || (s.YearId == 54 && c.CountryId == 86)
                            || (s.YearId == 54 && c.CountryId == 96)
                            //group s.OilProductionByBarrel by c.CountryArName into mygroup
                            select new OilItem
                            {
                                CountryArName = c.CountryArName,// mygroup.Key,
                                Value = s.OilProductionByBarrel.Value//   mygroup.Sum(i => i.Value)
                            }).OrderByDescending(v => v.Value);


                var result = from p in data select new { p.CountryArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج الشرق الأوسط للنفط بالمليون طن			
        public ActionResult _Partial18Data1()
        {
            try
            {
                var data = (from s in DB.OilProductionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId

                            where (s.YearId == 54 && c.CountryId == 79)
                            || (s.YearId == 54 && c.CountryId == 150)
                            || (s.YearId == 54 && c.CountryId == 92)
                            || (s.YearId == 54 && c.CountryId == 80)
                            || (s.YearId == 54 && c.CountryId == 140)
                            || (s.YearId == 54 && c.CountryId == 181)
                            || (s.YearId == 54 && c.CountryId == 13)
                            || (s.YearId == 54 && c.CountryId == 130)
                            || (s.YearId == 54 && c.CountryId == 168)
                            || (s.YearId == 54 && c.CountryId == 190)
                            || (s.YearId == 54 && c.CountryId == 86)
                            || (s.YearId == 54 && c.CountryId == 96)

                            select new OilItem
                            {
                                CountryArName = c.CountryArName,// mygroup.Key,
                                Value = s.OilProductionByTonne.Value//   mygroup.Sum(i => i.Value)
                            }).OrderByDescending(v => v.Value);


                var result = from p in data select new { p.CountryArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج السعودية من النفط بالبرميل
        public ActionResult _Partial19Data1()
        {
            try
            {
                var data = (from s in DB.OilProductionCountries
                            where (
                              s.YearId == 6 && s.CountryId == 150
                            || s.YearId == 16 && s.CountryId == 150
                            || s.YearId == 26 && s.CountryId == 150
                            || s.YearId == 36 && s.CountryId == 150
                            || s.YearId == 46 && s.CountryId == 150
                            || s.YearId == 54 && s.CountryId == 150
                            )
                            group s.OilProductionByBarrel by s.Year.YearN into mygroup
                            select new OilItem
                            {
                                YearName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            }).OrderBy(o => o.Value);


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج السعودية من النفط بالطن
        public ActionResult _Partial20Data1()
        {
            try
            {
                var data = (from s in DB.OilProductionCountries
                            where (
                              s.YearId == 6 && s.CountryId == 150
                            || s.YearId == 16 && s.CountryId == 150
                            || s.YearId == 26 && s.CountryId == 150
                            || s.YearId == 36 && s.CountryId == 150
                            || s.YearId == 46 && s.CountryId == 150
                            || s.YearId == 54 && s.CountryId == 150
                            )
                            group s.OilProductionByTonne by s.Year.YearN into mygroup
                            select new OilItem
                            {
                                YearName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            }).OrderBy(o => o.Value);


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // اكبر دول العالم لانتاج البترول بالبرميل لعام 2013
        public ActionResult _Partial21Data()
        {
            try
            {
                var data = (from s in DB.OilProductionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId
                            where (s.YearId == 54)
                            select new OilItem
                            {
                                CountryArName = c.CountryArName,
                                Value = s.OilProductionByBarrel.Value
                            }).OrderByDescending(o => o.Value);
                var result = (from p in data
                              select new
                              {
                                  p.CountryArName,
                                  p.Value
                              }).Take(10);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // اكبر دول العالم لانتاج البترول بالطن لعام 2013
        public ActionResult _Partial22Data()
        {
            try
            {
                var data = (from s in DB.OilProductionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId
                            where (
                              s.YearId == 54
                            )
                            select new OilItem
                            {
                                CountryArName = c.CountryArName,
                                Value = s.OilProductionByTonne.Value
                            }).OrderByDescending(o => o.Value);
                var result = (from p in data
                              select new
                              {
                                  p.CountryArName,
                                  p.Value
                              }).Take(10);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج  النفط حسب الاوبك وغير الاوبك بالبرميل
        public ActionResult _Partial23Data()
        {
            try
            {
                var data = (from s in DB.OilProductionRegions
                            where (s.YearId == 54 && s.RegionId == 24)
                            || (s.YearId == 54 && s.RegionId == 25)

                            select new OilItem
                            {
                                RegionEnName = s.Region.RegionEnName,
                                Value = s.OilProductionByBarrel.Value
                            }).OrderByDescending(o => o.Value);

                var result = from p in data select new { p.RegionEnName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //انتاج  النفط حسب الاوبك وغير الاوبك بالطن
        public ActionResult _Partial24Data()
        {
            try
            {
                var data = (from s in DB.OilProductionRegions
                            where (s.YearId == 54 && s.RegionId == 24)
                            || (s.YearId == 54 && s.RegionId == 25)

                            select new OilItem
                            {
                                RegionEnName = s.Region.RegionEnName,
                                Value = s.OilProductionByTonne.Value
                            }).OrderByDescending(o => o.Value);

                var result = from p in data select new { p.RegionEnName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region استهلاك النفط

        //استهلاك العالم للنفط من 65-2013 بالبرميل
        public JsonResult _Partial25Data()
        {
            try
            {
                var data = from s in DB.OilConsumptionCountries
                           where (
                             s.YearId == 6
                           || s.YearId == 16
                           || s.YearId == 26
                           || s.YearId == 36
                           || s.YearId == 46
                           || s.YearId == 54
                           )
                           group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //استهلاك العالم للنفط من 65-2013 بالطن
        public JsonResult _Partial26Data()
        {
            try
            {
                var data = from s in DB.OilConsumptionCountries
                           where (
                             s.YearId == 6
                           || s.YearId == 16
                           || s.YearId == 26
                           || s.YearId == 36
                           || s.YearId == 46
                           || s.YearId == 54
                           )
                           group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                           select new OilItem
                           {
                               YearName = mygroup.Key,
                               Value = mygroup.Sum(i => i.Value)
                           };


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //استهلاك العالم للنفط حسب المناطق بالبرميل
        public JsonResult _Partial27Data()
        {
            try
            {


                var data1 = (from s in DB.OilConsumptionRegions
                             where
                                 (s.YearId == 6 && s.RegionId == 20)
                              || (s.YearId == 16 && s.RegionId == 20)
                              || (s.YearId == 26 && s.RegionId == 20)
                              || (s.YearId == 36 && s.RegionId == 20)
                              || (s.YearId == 46 && s.RegionId == 20)
                              || (s.YearId == 54 && s.RegionId == 20)
                             group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result1 = from p in data1 select new { p.YearName, p.Value };


                var data2 = (from s in DB.OilConsumptionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 18)
                             || (s.YearId == 16 && s.RegionId == 18)
                             || (s.YearId == 26 && s.RegionId == 18)
                             || (s.YearId == 36 && s.RegionId == 18)
                             || (s.YearId == 46 && s.RegionId == 18)
                             || (s.YearId == 54 && s.RegionId == 18)
                             group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result2 = from p in data2 select new { p.YearName, p.Value };
                var data3 = (from s in DB.OilConsumptionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 17)
                             || (s.YearId == 16 && s.RegionId == 17)
                             || (s.YearId == 26 && s.RegionId == 17)
                             || (s.YearId == 36 && s.RegionId == 17)
                             || (s.YearId == 46 && s.RegionId == 17)
                             || (s.YearId == 54 && s.RegionId == 17)
                             group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result3 = from p in data3 select new { p.YearName, p.Value };
                var data4 = (from s in DB.OilConsumptionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 19)
                             || (s.YearId == 16 && s.RegionId == 19)
                             || (s.YearId == 26 && s.RegionId == 19)
                             || (s.YearId == 36 && s.RegionId == 19)
                             || (s.YearId == 46 && s.RegionId == 19)
                             || (s.YearId == 54 && s.RegionId == 19)
                             group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result4 = from p in data4 select new { p.YearName, p.Value };
                var data5 = (from s in DB.OilConsumptionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 21)
                             || (s.YearId == 16 && s.RegionId == 21)
                             || (s.YearId == 26 && s.RegionId == 21)
                             || (s.YearId == 36 && s.RegionId == 21)
                             || (s.YearId == 46 && s.RegionId == 21)
                             || (s.YearId == 54 && s.RegionId == 21)
                             group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result5 = from p in data5 select new { p.YearName, p.Value };
                var data6 = (from s in DB.OilConsumptionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 22)
                             || (s.YearId == 16 && s.RegionId == 22)
                             || (s.YearId == 26 && s.RegionId == 22)
                             || (s.YearId == 36 && s.RegionId == 22)
                             || (s.YearId == 46 && s.RegionId == 22)
                             || (s.YearId == 54 && s.RegionId == 22)
                             group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result6 = from p in data6 select new { p.YearName, p.Value };
                return Json(new { FirstList = result1, SecondList = result2, ThirdList = result3, FourthList = result4, FivethList = result5, SixList = result6 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //استهلاك العالم للنفط حسب المناطق بالطن
        public JsonResult _Partial28Data()
        {
            try
            {
                var data1 = (from s in DB.OilConsumptionRegions
                             where
                                 (s.YearId == 6 && s.RegionId == 20)
                              || (s.YearId == 16 && s.RegionId == 20)
                              || (s.YearId == 26 && s.RegionId == 20)
                              || (s.YearId == 36 && s.RegionId == 20)
                              || (s.YearId == 46 && s.RegionId == 20)
                              || (s.YearId == 54 && s.RegionId == 20)
                             group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result1 = from p in data1 select new { p.YearName, p.Value };


                var data2 = (from s in DB.OilConsumptionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 18)
                             || (s.YearId == 16 && s.RegionId == 18)
                             || (s.YearId == 26 && s.RegionId == 18)
                             || (s.YearId == 36 && s.RegionId == 18)
                             || (s.YearId == 46 && s.RegionId == 18)
                             || (s.YearId == 54 && s.RegionId == 18)
                             group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result2 = from p in data2 select new { p.YearName, p.Value };
                var data3 = (from s in DB.OilConsumptionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 17)
                             || (s.YearId == 16 && s.RegionId == 17)
                             || (s.YearId == 26 && s.RegionId == 17)
                             || (s.YearId == 36 && s.RegionId == 17)
                             || (s.YearId == 46 && s.RegionId == 17)
                             || (s.YearId == 54 && s.RegionId == 17)
                             group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result3 = from p in data3 select new { p.YearName, p.Value };
                var data4 = (from s in DB.OilConsumptionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 19)
                             || (s.YearId == 16 && s.RegionId == 19)
                             || (s.YearId == 26 && s.RegionId == 19)
                             || (s.YearId == 36 && s.RegionId == 19)
                             || (s.YearId == 46 && s.RegionId == 19)
                             || (s.YearId == 54 && s.RegionId == 19)
                             group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result4 = from p in data4 select new { p.YearName, p.Value };
                var data5 = (from s in DB.OilConsumptionRegions
                             where
                               (s.YearId == 6 && s.RegionId == 21)
                             || (s.YearId == 16 && s.RegionId == 21)
                             || (s.YearId == 26 && s.RegionId == 21)
                             || (s.YearId == 36 && s.RegionId == 21)
                             || (s.YearId == 46 && s.RegionId == 21)
                             || (s.YearId == 54 && s.RegionId == 21)
                             group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result5 = from p in data5 select new { p.YearName, p.Value };
                var data6 = (from s in DB.OilConsumptionRegions
                             where
                                (s.YearId == 6 && s.RegionId == 22)
                             || (s.YearId == 16 && s.RegionId == 22)
                             || (s.YearId == 26 && s.RegionId == 22)
                             || (s.YearId == 36 && s.RegionId == 22)
                             || (s.YearId == 46 && s.RegionId == 22)
                             || (s.YearId == 54 && s.RegionId == 22)
                             group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                             select new OilItem
                             {
                                 YearName = mygroup.Key,
                                 Value = mygroup.Sum(i => i.Value)
                             });


                var result6 = from p in data6 select new { p.YearName, p.Value };
                return Json(new { FirstList = result1, SecondList = result2, ThirdList = result3, FourthList = result4, FivethList = result5, SixList = result6 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //استهلاك الشرق الاوسط للنفط عام2013 بالالف برميل
        public JsonResult _Partial29Data()
        {
            try
            {
                var data = (from s in DB.OilConsumptionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId

                            where (s.YearId == 54 && c.CountryId == 79)
                            || (s.YearId == 54 && c.CountryId == 150)
                            || (s.YearId == 54 && c.CountryId == 92)
                            || (s.YearId == 54 && c.CountryId == 80)
                            || (s.YearId == 54 && c.CountryId == 140)
                            || (s.YearId == 54 && c.CountryId == 181)
                            || (s.YearId == 54 && c.CountryId == 13)
                            || (s.YearId == 54 && c.CountryId == 130)
                            || (s.YearId == 54 && c.CountryId == 168)
                            || (s.YearId == 54 && c.CountryId == 190)
                            || (s.YearId == 54 && c.CountryId == 86)
                            || (s.YearId == 54 && c.CountryId == 96)

                            select new OilItem
                            {
                                CountryArName = c.CountryArName,// mygroup.Key,
                                Value = s.OilConsumptionByBarrel.Value//   mygroup.Sum(i => i.Value)
                            }).OrderByDescending(v => v.Value);


                var result = from p in data select new { p.CountryArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //استهلاك الشرق الاوسط للنفط عام2013 بالالف برميل
        public JsonResult _Partial30Data()
        {
            try
            {
                var data = (from s in DB.OilConsumptionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId
                            where (s.YearId == 54 &&
                                   //c.Regions.FirstOrDefault().RegionId==20
                                   c.CountryId == 79)
                            || (s.YearId == 54 && c.CountryId == 150)
                            || (s.YearId == 54 && c.CountryId == 92)
                            || (s.YearId == 54 && c.CountryId == 140)
                            || (s.YearId == 54 && c.CountryId == 181)
                            select new OilItem
                            {
                                CountryArName = c.CountryArName, //c.CountryArName,// mygroup.Key,
                                Value = s.OilConsumptionByTonne.Value// mygroup.Sum(i => i.Value)
                            }).AsQueryable().OrderByDescending(v => v.Value);
                var result = from p in data select new { p.CountryArName, p.Value };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //استهلاك السعودية من النفط بالبرميل
        public JsonResult _Partial31Data()
        {
            try
            {
                var data = (from s in DB.OilConsumptionCountries
                            where (
                               s.YearId == 6 && s.CountryId == 150
                            || s.YearId == 16 && s.CountryId == 150
                            || s.YearId == 26 && s.CountryId == 150
                            || s.YearId == 36 && s.CountryId == 150
                            || s.YearId == 46 && s.CountryId == 150
                            || s.YearId == 54 && s.CountryId == 150
                            )
                            group s.OilConsumptionByBarrel by s.Year.YearN into mygroup
                            select new OilItem
                            {
                                YearName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            }).OrderBy(o => o.Value);


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        //استهلاك السعودية من النفط بالطن
        public JsonResult _Partial32Data()
        {
            try
            {
                var data = (from s in DB.OilConsumptionCountries
                            where (
                               s.YearId == 6 && s.CountryId == 150
                            || s.YearId == 16 && s.CountryId == 150
                            || s.YearId == 26 && s.CountryId == 150
                            || s.YearId == 36 && s.CountryId == 150
                            || s.YearId == 46 && s.CountryId == 150
                            || s.YearId == 54 && s.CountryId == 150
                            )
                            group s.OilConsumptionByTonne by s.Year.YearN into mygroup
                            select new OilItem
                            {
                                YearName = mygroup.Key,
                                Value = mygroup.Sum(i => i.Value)
                            }).OrderBy(o => o.Value);


                var result = from p in data select new { p.YearName, p.Value };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // اكبر دول العالم لاستهلاك البترول بالبرميل لعام 2013
        public ActionResult _Partial33Data()
        {
            try
            {
                var data = (from s in DB.OilConsumptionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId
                            where (s.YearId == 54)
                            select new OilItem
                            {
                                CountryArName = c.CountryArName,
                                Value = s.OilConsumptionByBarrel.Value
                            }).OrderByDescending(o => o.Value);
                var result = (from p in data
                              select new
                              {
                                  p.CountryArName,
                                  p.Value
                              }).Take(10);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // اكبر دول العالم لاستهلاك البترول بالطن لعام 2013
        public ActionResult _Partial34Data()
        {
            try
            {
                var data = (from s in DB.OilConsumptionCountries
                            join c in DB.Countries
                                on s.CountryId equals c.CountryId
                            where (s.YearId == 54)
                            select new OilItem
                            {
                                CountryArName = c.CountryArName,
                                Value = s.OilConsumptionByTonne.Value
                            }).OrderByDescending(o => o.Value);
                var result = (from p in data
                              select new
                              {
                                  p.CountryArName,
                                  p.Value
                              }).Take(10);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
        #endregion
        //============================================================================
        #region Banks
        public JsonResult _Partial100Data(int? bankCode)
        {
            try
            {
                //int m = DB.Years.Max(a => a.YearId);
                var result = (from b in DB.Bank_Year
                              where b.Bank.BankCode == bankCode && b.BranchsBank != 0
                              select new
                              {
                                  bYear = b.Year.YearN,
                                  bCount = b.ATMMachine,
                                  bName = b.Bank.BankArName
                              });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }//الصرافات
        public JsonResult _Partial101Data()
        {
            try
            {
                var result = (from b in DB.Bank_Year
                              where b.YearId == 55
                              select new
                              {
                                  bName = b.Bank.BankArName,
                                  bCount = b.BranchsBank
                              }).OrderByDescending(a => a.bCount);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }//فروع المصارف
        public JsonResult _Partial102Data(int? bankCode)
        {
            try
            {
                //int m = DB.Years.Max(a => a.YearId);
                var result = (from b in DB.Bank_Year
                              where b.Bank.BankCode == bankCode && b.BranchsBank != 0
                              select new
                              {
                                  bYear = b.Year.YearN,
                                  bCount = b.BranchsBank,
                                  bName = b.Bank.BankArName
                              });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }  //فروع مصرف الإنماء
        public JsonResult _Partial103Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 1
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //عائد السهم
        public JsonResult _Partial104Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 2
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //الاستثمار / الودائع %
        public JsonResult _Partial105Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 3
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //-القروض / الودائع %
        public JsonResult _Partial106Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 4
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //القيمة الدفترية للسهم
        public JsonResult _Partial107Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 5
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //نسبة سعر السوق / عائد السهم
        public JsonResult _Partial108Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 6
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //مكرر القيمة الدفترية(PE)
        public JsonResult _Partial109Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 7
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //العائد على حقوق المساهمين
        public JsonResult _Partial110Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 8
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //العائد على إجمالي الموجودات
        public JsonResult _Partial111Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 9
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //إجمالي الربح
        public JsonResult _Partial112Data()
        {
            try
            {
                var result = from b in DB.FinanceIndexValues
                             where b.FinanceIndexId == 10
                             select new
                             {
                                 bName = b.Year.YearN,
                                 bCount = b.IndexValue
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        } //صافى الربح
        
        #endregion
    }
}

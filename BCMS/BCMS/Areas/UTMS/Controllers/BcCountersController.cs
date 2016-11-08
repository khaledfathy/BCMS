using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using BCMS.Areas.UTMS.Models;
using BCMS.Models;

namespace BCMS.Areas.UTMS.Controllers
{
    public class BcCountersController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        OleDbConnection oledbConn;
        private JsonResult GenerateExcelData()
        {
            try
            {
                string path = System.IO.Path.GetFullPath(HostingEnvironment.MapPath("~/App_Data/counters.xlsx"));


                if (Path.GetExtension(path) == ".xls")
                {
                    oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                }
                else if (Path.GetExtension(path) == ".xlsx")
                {
                    oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                }

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = oledbConn;
                oledbConn.Open();
                cmd.CommandText = "SELECT * FROM [Sheet1$] WHERE( [Sheet1$].[Name]=" + "'khaled'" + ")";
                OleDbDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                oledbConn.Close();
                return Json(dt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult selectAllMarkets()
        {
            try
            {
                #region select From Excel
                /*
                string path = System.IO.Path.GetFullPath(HostingEnvironment.MapPath("~/App_Data/BcCounter.xlsx"));

                if (Path.GetExtension(path) == ".xls")
                {
                    oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                }
                else if (Path.GetExtension(path) == ".xlsx")
                {
                    oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                }

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = oledbConn;
                oledbConn.Open();
                cmd.CommandText = "SELECT *  FROM [Sheet1$]";
                OleDbDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                oledbConn.Close();
                var result = (from b in dt.AsEnumerable()
                              select new Counter
                              {
                                  Code = b.Field<double>("السهم"),
                                  CompanyName = b.Field<string>("اسم السهم"),
                                  CashFlowIn = b.Field<double>("حجم السيولة الداخلة"),
                                  CashFlowOut = b.Field<double>("حجم السيولة الخارجة"),
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
                */
                #endregion
                var result = DB.Tadawels.Select(x => new
                {
                    CODE = x.CODE,
                    NAME = x.NAME,
                    CASHFLOWIN = x.CASHFLOWIN,
                    CASHFLOWOUT = x.CASHFLOWIN,
                    TREND = x.TREND,
                    CHANGE = x.CHANGE,
                    CHANGEPEST = x.CHANGEPEST,
                    BESTASKQ = x.BESTASKQ,
                    BESTBIDP = x.BESTBIDP,
                    BESTBIDQ = x.BESTBIDQ,
                    VOLUME = x.VOLUME,
                    VALUE = x.VALUE,
                    TRANSACTIONS = x.TRANSACTIONS,
                    ASKBID = x.ASKBID,
                    CASHFLOWPLAN = x.CASHFLOWPLAN

                }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            

        }
        [HttpGet]
        public ActionResult selectMarketData(double code)
        {
            try
            {
                #region select from Excel 
                /*
               string path = System.IO.Path.GetFullPath(HostingEnvironment.MapPath("~/App_Data/BcCounter.xlsx"));

               if (Path.GetExtension(path) == ".xls")
               {
                   oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
               }
               else if (Path.GetExtension(path) == ".xlsx")
               {
                   oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
               }

               OleDbCommand cmd = new OleDbCommand();
               cmd.Connection = oledbConn;
               oledbConn.Open();
               cmd.CommandText = "SELECT *  FROM [Sheet1$] WHERE( [Sheet1$].[السهم]=" + code + ")";
               OleDbDataReader reader = cmd.ExecuteReader();
               DataTable dt = new DataTable();
               dt.Load(reader);
               oledbConn.Close();
               var result = (from b in dt.AsEnumerable()
                             select new Counter
                             {
                                 //Code = b.Field<double>("السهم"),
                                 CompanyName = b.Field<string>("اسم السهم"),
                                 CashFlowIn = b.Field<double>("حجم السيولة الداخلة"),
                                 CashFlowOut = b.Field<double>("حجم السيولة الخارجة"),
                             }).ToList();
               return Json(result, JsonRequestBehavior.AllowGet);
               */

                #endregion
                var result = DB.Tadawels.Where(w => w.CODE == code).Select(c => new
                {
                    c.NAME,
                    c.CASHFLOWIN,
                    c.CASHFLOWOUT
                }
                ).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}
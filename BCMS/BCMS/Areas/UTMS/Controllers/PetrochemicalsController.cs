using BCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    public class PetrochemicalsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public JsonResult GetAllPetrochemicals()
        {

            return Json(DB.Petrochemical.Select(x => new {
                products=x.ProductName,
                usage = x.Usage,
                price = x.Price,
                SABIC_prod=x.Sabic36_Prod,
                SABIC_perc=x.Sabic36_Per,
                Petro_prod=x.Petrochem_Prod,
                Petro_perc=x.Petrochem_Per,
                SAFCO_prod=x.Safco2_Prod,
                SAFCO_perc=x.Safco2_Per,
                Kayan_prod=x.Kayan14_Prod,
                Kayan_perc=x.Kayan14_Per,
                Yansab_prod=x.Yansab15_Prod,
                Yansab_perc=x.Yansab15_Per,
                Sipchem_prod=x.Sipchem8_Prod,
                Sipchem_perc=x.Sipchem8_Per,
                SIIG_prod=x.Siig10_Prod,
                SIIG_perc=x.Siig10_Per,
                Tasnee_prod=x.Tasnee8_Prod,
                Tasnee_perc=x.Tasnee8_Per,
                Sahara_prod=x.Sahara8_Prod,
                Sahara_perc=x.Sahara8_Per,
                Chemanol_prod = x.Chemanol10_Prod,
                Chemanol_perc=x.Chemanol10_Per,
                Alujain_prod=x.Alujain1_Prod,
                Alujain_perc=x.Alujain1_Per,
                Adv_prod=x.Advanced_Prod,
                Adv_perc=x.Advanced_Per,
                Nama_prod=x.Nama_Prod,
                Nama_perc=x.Nama_Per            
            }), JsonRequestBehavior.AllowGet);
        }

    }
}

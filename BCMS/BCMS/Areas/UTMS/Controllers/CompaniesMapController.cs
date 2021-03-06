﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;

namespace BCMS.Areas.UTMS.Controllers
{
    public class CompaniesMapController : Controller
    {

        BorsaCapitalDataModel db = new BorsaCapitalDataModel();

        public ActionResult Index()
        {
            try
            {
                ViewBag.AllSectors = new SelectList(db.Sectors.Select(s => new { s.RecordID, s.SectorName }), "RecordID", "SectorName");
                return View();
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllCompanies()
        {
            try
            {
                var model = db.CompanyInfoes.Select(c => new { c.Longitude, c.latitude, c.CompanyID, c.CompanyShortName, c.Sector.SectorName, c.CompanyMain_Office, c.CompanyWork_sites, c.CompanyIncorporation, c.CompanyPaid_Up_Capital, c.CompanyInfoDate }).Where(w => w.Longitude != null && w.latitude != null);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetAllCompaniesBySector( int SectorID )
        {
            try
            {
                if (SectorID == 0)
                {
                    var model = db.CompanyInfoes.Select(c => new { c.Longitude, c.latitude, c.CompanyID, c.CompanyShortName, c.Sector.SectorName, c.CompanyMain_Office, c.CompanyWork_sites, c.CompanyIncorporation, c.CompanyPaid_Up_Capital, c.CompanyInfoDate }).Where(w => w.Longitude != null && w.latitude != null);
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var model = db.CompanyInfoes.Where(w => w.SectorID == SectorID && w.Longitude != null && w.latitude != null).Select(c => new { c.Longitude, c.latitude, c.CompanyID, c.CompanyShortName, c.Sector.SectorName, c.CompanyMain_Office, c.CompanyWork_sites, c.CompanyIncorporation, c.CompanyPaid_Up_Capital, c.CompanyInfoDate });
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult GetAllCompaniesByCompanyCode(int CompanyCode)
        {
            try
            {
                var model = db.CompanyInfoes.Where(w => w.CompanyID == CompanyCode && w.Longitude != null && w.latitude != null).Select(c => new { c.Longitude, c.latitude, c.CompanyID, c.CompanyShortName, c.Sector.SectorName, c.CompanyMain_Office, c.CompanyWork_sites, c.CompanyIncorporation, c.CompanyPaid_Up_Capital, c.CompanyInfoDate });
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

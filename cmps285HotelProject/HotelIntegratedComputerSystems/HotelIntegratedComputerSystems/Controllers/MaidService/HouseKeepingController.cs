using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;
using System.Web.UI;
using HotelIntegratedComputerSystems.Services;

namespace HotelIntegratedComputerSystems.Controllers
{
    public class HouseKeepingController : BaseController
    {
        private MaidServiceServices Service = new MaidServiceServices();

        public ActionResult Index()
        {
            return View(Service.GetRoomsForHouseKeeping());
        }
        
        public ActionResult Clean(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service.ChangeCleanStatus(Service.GetCleanStatusIndex("Clean"), id.Value);
            return RedirectToAction("Index");
        }

        public ActionResult Dirty(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service.ChangeCleanStatus(Service.GetCleanStatusIndex("Dirty"), id.Value);
            return RedirectToAction("Index");
        }

        public ActionResult DND(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service.ChangeCleanStatus(Service.GetCleanStatusIndex("Do Not Disturb"), id.Value);
            return RedirectToAction("Index");
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

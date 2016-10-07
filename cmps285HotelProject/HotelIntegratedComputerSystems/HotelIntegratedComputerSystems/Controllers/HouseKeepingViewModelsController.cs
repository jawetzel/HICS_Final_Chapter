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

namespace HotelIntegratedComputerSystems.Controllers
{
    public class HouseKeepingViewModelsController : Controller
    {
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: HouseKeepingViewModels
        public ActionResult Index()
        {
            return View(db.GetRoomsForHouseKeeping());
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room ChangeRoom = db.Rooms.Where(s => s.Id == id).FirstOrDefault<Room>();
            ChangeRoom.HousekeepingStatusId = 1;

            db.Entry(ChangeRoom).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: HouseKeepingViewModels/Delete/5
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

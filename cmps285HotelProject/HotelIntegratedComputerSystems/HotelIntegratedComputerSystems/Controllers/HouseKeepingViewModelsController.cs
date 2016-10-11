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
        
        public ActionResult Clean(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseKeepingStatu RoomStatus = db.HouseKeepingStatus.Where(s => s.CleanStatus.Contains("Clean")).FirstOrDefault<HouseKeepingStatu>();
            Room ChangeRoom = db.Rooms.Where(s => s.Id == id).FirstOrDefault<Room>();
            ChangeRoom.HousekeepingStatusId = RoomStatus.Id;

            db.Entry(ChangeRoom).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dirty(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseKeepingStatu RoomStatus = db.HouseKeepingStatus.Where(s => s.CleanStatus.Contains("Dirty")).FirstOrDefault<HouseKeepingStatu>();
            Room ChangeRoom = db.Rooms.Where(s => s.Id == id).FirstOrDefault<Room>();
            ChangeRoom.HousekeepingStatusId = RoomStatus.Id;

            db.Entry(ChangeRoom).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DND(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseKeepingStatu RoomStatus = db.HouseKeepingStatus.Where(s => s.CleanStatus.Contains("Do Not Disturb")).FirstOrDefault<HouseKeepingStatu>();
            Room ChangeRoom = db.Rooms.Where(s => s.Id == id).FirstOrDefault<Room>();
            ChangeRoom.HousekeepingStatusId = RoomStatus.Id;

            db.Entry(ChangeRoom).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult UpdateRoomList(string Building, string Floor, string Room, string CleanStatus, string RoomStatus)
        //{
        //    if (model.matId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //do something here
        //    return RedirectToAction("Index")
        //}


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

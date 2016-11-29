using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.Admin;
using HotelIntegratedComputerSystems.Controllers.Default;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class RoomsController : BaseController
    {
        private readonly RoomServices _services = new RoomServices();

        public ActionResult Index()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetRoomList());
        }

        public ActionResult Create()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            ViewBag.BuildingId = new SelectList(Db.Buildings, "Id", "BuildingName");
            ViewBag.HousekeepingStatusId = new SelectList(Db.HouseKeepingStatus, "Id", "CleanStatus");
            ViewBag.RoomTypeId = new SelectList(Db.RoomTypes, "Id", "Bedding");
            ViewBag.RoomStatusId = new SelectList(Db.RoomStatus, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BuildingId,BuildingName,RoomTypeId,HouseKeepingStatusId,HouseKeepingStatus,RoomStatusId,RoomStatus,FloorNumber,RoomNumber")] RoomViewModel roomViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(roomViewModel);
            _services.CreateNewRoom(roomViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            ViewBag.BuildingId = new SelectList(Db.Buildings, "Id", "BuildingName");
            ViewBag.HousekeepingStatusId = new SelectList(Db.HouseKeepingStatus, "Id", "CleanStatus");
            ViewBag.RoomTypeId = new SelectList(Db.RoomTypes, "Id", "Bedding");
            ViewBag.RoomStatusId = new SelectList(Db.RoomStatus, "Id", "Description");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roomViewModel = _services.FindEntryById(id.Value);
            if (roomViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roomViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BuildingId,BuildingName,RoomTypeId,HouseKeepingStatusId,HouseKeepingStatus,RoomStatusId,RoomStatus,FloorNumber,RoomNumber")] RoomViewModel roomViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(roomViewModel);
            _services.PostChangesForEdit(roomViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (_services.CheckForDependencys(id.Value))
            {
                return View("DeleteError");
            }

            var roomViewModel = _services.FindEntryById(id.Value);
            if (roomViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roomViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }

    }
}

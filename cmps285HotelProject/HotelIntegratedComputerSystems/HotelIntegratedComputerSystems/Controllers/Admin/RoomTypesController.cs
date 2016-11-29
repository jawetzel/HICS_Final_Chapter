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
    public class RoomTypesController : Controller
    {
        private readonly RoomTypeServices _services = new RoomTypeServices();

        public ActionResult Index()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetRoomTypesList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bedding,Kitchen,Rooms,BathRooms,SleepsVolume,NightlyRate")] RoomTypeViewModel roomTypeViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(roomTypeViewModel);
            _services.CreateNewRoomType(roomTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roomTypeViewModel = _services.FindEntryById(id.Value);
            if (roomTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roomTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bedding,Kitchen,Rooms,BathRooms,SleepsVolume,NightlyRate")] RoomTypeViewModel roomTypeViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(roomTypeViewModel);
            _services.PostChangesForEdit(roomTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (_services.CheckForDependencys(id.Value))
            {
                return View("DeleteError");
            }

            var roomTypeViewModel = _services.FindEntryById(id.Value);
            if (roomTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roomTypeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

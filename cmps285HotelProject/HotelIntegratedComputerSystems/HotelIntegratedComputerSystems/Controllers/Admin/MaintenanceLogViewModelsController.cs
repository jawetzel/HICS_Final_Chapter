using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin.MaintenanceLog;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class MaintenanceLogViewModelsController : BaseController
    {
        private MaintenanceLogServices _services = new MaintenanceLogServices();

        public ActionResult Index()
        {
            return View(_services.GetMaintenanceLogList());
        }

        public ActionResult Create()
        {
            return View(_services.RoomsForMaintenaneLogCreateEdit());
        }

        // POST: MaintenanceLogViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,RoomId,BuildingId,BuildingName,Floor,RoomNumber,Description,Date,MaintenanceTypeId,MaintenanceType")] MaintenanceLogViewModel maintenanceLogViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.MaintenanceLogViewModels.Add(maintenanceLogViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(maintenanceLogViewModel);
        //}

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintLog = _services.FindEntryById(id.Value);
            var roomsLog = _services.RoomsForMaintenaneLogCreateEdit();
            maintLog.RoomsList = roomsLog.RoomsList;
            if (maintLog.MaintenanceLog == null)
            {
                return HttpNotFound();
            }
            return View(maintLog);
        }

        //POST: MaintenanceLogViewModels/Edit/5
         //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoomId,BuildingId,BuildingName,Floor,RoomNumber,Description,Date,MaintenanceTypeId,MaintenanceType")] PackageMaintenanceLogViewModel maintenanceLogViewModel)
        {
            if (ModelState.IsValid)
            {
                _services.PostChangesForEdit(maintenanceLogViewModel);
                return RedirectToAction("Index");
            }
            return View(maintenanceLogViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceLogViewModel = _services.FindEntryById(id.Value);
            if (maintenanceLogViewModel == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceLogViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

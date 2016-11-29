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
    public class MaintenanceTypesController : BaseController
    {
        private readonly MaintenanceTypeServices _services = new MaintenanceTypeServices();

        public ActionResult Index()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetMaintenanceTypeList());
        }

        public ActionResult Create()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] MaintenanceTypeViewModel maintenanceTypeViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(maintenanceTypeViewModel);
            _services.CreateMaintenanceType(maintenanceTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceTypeViewModel = _services.FindEntryById(id.Value);
            if (maintenanceTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] MaintenanceTypeViewModel maintenanceTypeViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(maintenanceTypeViewModel);
            _services.PostChangesForEdit(maintenanceTypeViewModel);
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
            var maintenanceTypeViewModel = _services.FindEntryById(id.Value);
            if (maintenanceTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceTypeViewModel);
        }

        // POST: MaintenanceTypeViewModels/Delete/5
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

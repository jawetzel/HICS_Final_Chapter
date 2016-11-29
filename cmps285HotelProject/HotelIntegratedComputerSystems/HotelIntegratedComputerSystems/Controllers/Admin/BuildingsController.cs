using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.Admin;
using HotelIntegratedComputerSystems.Controllers.Default;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class BuildingsController : BaseController
    {
        private readonly BuildingServices _services = new BuildingServices();

        public ActionResult Index()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4){ return Redirect("~/NotAuthorized/Index"); }

            return View(_services.GetBuildingsList());
        }


        public ActionResult Create()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Phone,Address,BuildingName")] BuildingViewModel buildingViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(buildingViewModel);
            _services.CreateNewBuilding(buildingViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var returnBuilding = _services.FindEntryById(id.Value);
            if (returnBuilding == null)
            {
                return HttpNotFound();
            }
            return View(returnBuilding);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Phone,Address,BuildingName")] BuildingViewModel buildingViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(buildingViewModel);
            _services.PostChangesForEdit(buildingViewModel);
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
            var buildingViewModel = _services.FindEntryById(id.Value);
            if (buildingViewModel == null)
            {
                return HttpNotFound();
            }
            return View(buildingViewModel);
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

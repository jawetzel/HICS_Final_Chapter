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

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class BuildingsController : BaseController
    {
        private readonly BuildingServices _services = new BuildingServices();

        public ActionResult Index()
        {
            return View(_services.GetBuildingsList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Phone,Address,BuildingName")] BuildingViewModel buildingViewModel)
        {
            if (!ModelState.IsValid) return View(buildingViewModel);
            _services.CreateNewCustomer(buildingViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
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
            if (!ModelState.IsValid) return View(buildingViewModel);
            _services.PostChangesForEdit(buildingViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

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
    public class EmployeeTypesController : BaseController
    {
        private readonly EmployeeTypeServices _services = new EmployeeTypeServices();

        public ActionResult Index()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetEmployeeTypeList());
        }


        public ActionResult Create()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            ViewBag.SecurityRankId = new SelectList(Db.SecurityRanks, "Id", "AccessLevelDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SecurityRankId,SecurityRankDescription,Title,PayRate")] EmployeeTypeViewModel employeeTypeViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(employeeTypeViewModel);
            _services.CreateNewEmployeeType(employeeTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.SecurityRank = new SelectList(Db.SecurityRanks, "Id", "AccessLevelDescription");
            var employeeTypeViewModel = _services.FindEntryById(id.Value);
            if (employeeTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SecurityRankId,SecurityRankDescription,Title,PayRate")] EmployeeTypeViewModel employeeTypeViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(employeeTypeViewModel);
            _services.PostChangesForEdit(employeeTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (_services.CheckForDependencys(id.Value))
            {
                return View("DeleteError");
            }

            var employeeTypeViewModel = _services.FindEntryById(id.Value);
            if (employeeTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeTypeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

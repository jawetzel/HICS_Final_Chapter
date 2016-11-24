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
    public class EmployeesController : BaseController
    {
        private EmployeeServies _services = new EmployeeServies();

        public ActionResult Index()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetEmployeeList());
        }
        public ActionResult Create()
        {
           if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            ViewBag.EmployeeTypeId = new SelectList(Db.EmployeeTypes, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeTypeId,Name,EmployeeTypeTitle,Email,Address,Phone")] EmployeeViewModel employeeViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(employeeViewModel);
            _services.CreateNewEmployee(employeeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.EmployeeTypeId = new SelectList(Db.EmployeeTypes, "Id", "Title");
            var employeeViewModel = _services.FindEntryById(id.Value);
            if (employeeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeTypeId,Name,EmployeeTypeTitle,Email,Address,Phone")] EmployeeViewModel employeeViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(employeeViewModel);
            _services.PostChangesForEdit(employeeViewModel);
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
            var employeeViewModel = _services.FindEntryById(id.Value);
            if (employeeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeViewModel);
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

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

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class EmployeeTypesController : BaseController
    {
        private readonly EmployeeTypeServices _services = new EmployeeTypeServices();

        public ActionResult Index()
        {
            return View(_services.GetEmployeeTypeList());
        }


        public ActionResult Create()
        {
            ViewBag.SecurityRankId = new SelectList(Db.SecurityRanks, "Id", "AccessLevelDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SecurityRankId,SecurityRankDescription,Title,PayRate")] EmployeeTypeViewModel employeeTypeViewModel)
        {
            if (!ModelState.IsValid) return View(employeeTypeViewModel);
            _services.CreateNewEmployeeType(employeeTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
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
            if (!ModelState.IsValid) return View(employeeTypeViewModel);
            _services.PostChangesForEdit(employeeTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

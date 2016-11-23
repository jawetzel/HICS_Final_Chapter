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
    public class ExpenseTypesController : BaseController
    {
        private readonly ExpenseTypeServices _services = new ExpenseTypeServices();

        public ActionResult Index()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetExpenseTypesList());
        }

        public ActionResult Create()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Description,Ammount")] ExpenseTypeViewModel expenseTypeViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(expenseTypeViewModel);
            _services.CreateNewExpenseType(expenseTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseTypeViewModel = _services.FindEntryById(id.Value);
            if (expenseTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(expenseTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Description,Ammount")] ExpenseTypeViewModel expenseTypeViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(expenseTypeViewModel);
            _services.PostChangesForEdit(expenseTypeViewModel);
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

            var expenseTypeViewModel = _services.FindEntryById(id.Value);
            if (expenseTypeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(expenseTypeViewModel);
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

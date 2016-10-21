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
    public class ExpenseTypesController : BaseController
    {
        private readonly ExpenseTypeServices _services = new ExpenseTypeServices();

        public ActionResult Index()
        {
            return View(_services.GetExpenseTypesList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Description,Ammount")] ExpenseTypeViewModel expenseTypeViewModel)
        {
            if (!ModelState.IsValid) return View(expenseTypeViewModel);
            _services.CreateNewExpenseType(expenseTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
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
            if (!ModelState.IsValid) return View(expenseTypeViewModel);
            _services.PostChangesForEdit(expenseTypeViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
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
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }

    }
}

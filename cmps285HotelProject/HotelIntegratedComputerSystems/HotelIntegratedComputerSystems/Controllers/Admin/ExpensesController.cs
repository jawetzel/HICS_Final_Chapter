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
    public class ExpensesController : BaseController
    {
        private readonly ExpensesServices _services = new ExpensesServices();

        public ActionResult Index()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetExpensesList());
        }

        public ActionResult Create()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetExpenseByIdCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoomId,BuildingName,FloorNumber,RoomNumber,BookingId,CustomerName,ExpenseTypeId,ExpenseTypeType,ExpenseTypeDescription,ExpenseTypeAmmount")] ExpensesViewModel expensesViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (ModelState.IsValid)
            {
                _services.PostCreateExpense(expensesViewModel);
                return RedirectToAction("Index");
            }

            return View(expensesViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpensesViewModel expensesViewModel = _services.GetExpenseByIdEdit(id.Value);
            if (expensesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(expensesViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoomId,BuildingName,FloorNumber,RoomNumber,BookingId,CustomerName,ExpenseTypeId,ExpenseTypeType,ExpenseTypeDescription,ExpenseTypeAmmount")] ExpensesViewModel expensesViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (ModelState.IsValid)
            {
                _services.PostChangesForEdit(expensesViewModel);
                return RedirectToAction("Index");
            }
            return View(expensesViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpensesViewModel expensesViewModel = _services.GetExpenseByIdDelete(id.Value);
            if (expensesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(expensesViewModel);
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

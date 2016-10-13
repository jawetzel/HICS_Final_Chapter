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
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Services.Employee;

namespace HotelIntegratedComputerSystems.Controllers.Employees
{
    public class CustomersController : BaseController
    {
        private CustomerServices Service = new CustomerServices();

        public ActionResult Index()
        {
            return View(Service.GetCustomersList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (ModelState.IsValid)
            {
                Service.CreateNewCustomer(customersViewModel);
                return RedirectToAction("Index");
            }
            return View(customersViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersViewModel ReturnCustomer = Service.FindEntryById(id.Value);

            if (ReturnCustomer == null)
            {
                return HttpNotFound();
            }
            return View(ReturnCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (ModelState.IsValid)
            {
                Service.PostChangesForEdit(customersViewModel);
                return RedirectToAction("Index");
            }
            return View(customersViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersViewModel customersViewModel = Service.FindEntryById(id.Value);
            if (customersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customersViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

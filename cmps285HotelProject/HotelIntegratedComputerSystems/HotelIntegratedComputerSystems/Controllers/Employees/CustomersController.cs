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
using HotelIntegratedComputerSystems.Controllers.Default;

namespace HotelIntegratedComputerSystems.Controllers.Employees
{
    public class CustomersController : BaseController
    {
        private readonly CustomerServices _service = new CustomerServices();

        public ActionResult Index()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            var actionResult = View(_service.GetCustomersList());
            return actionResult;
        }

        public ActionResult Create()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            var actionResult = View();
            return actionResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(customersViewModel);
            _service.CreateNewCustomer(customersViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var returnCustomer = _service.FindEntryById(id.Value);

            if (returnCustomer == null)
            {
                return HttpNotFound();
            }
            return View(returnCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(customersViewModel);
            _service.PostChangesForEdit(customersViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (_service.CheckForDependencys(id.Value))
            {
                return View("DeleteError");
            }

            var customersViewModel = _service.FindEntryById(id.Value);
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
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            _service.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

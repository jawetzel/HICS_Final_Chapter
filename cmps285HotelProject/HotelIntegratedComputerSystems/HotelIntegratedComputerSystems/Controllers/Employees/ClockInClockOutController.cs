using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Controllers.Default;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.Admin;
using HotelIntegratedComputerSystems.Services.Employee;

namespace HotelIntegratedComputerSystems.Controllers.Employees
{
    public class ClockInClockOutController : BaseController
    {
        private ClockInServices _services = new ClockInServices();

        public ActionResult Index()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 0) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetShiftsForEmployee(Session["Name"].ToString()));
        }

        public ActionResult Create()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 0) { return Redirect("~/NotAuthorized/Index"); }
            var openShift = _services.GetOpenEmployeeShift(Session["Email"].ToString());
            if (openShift != 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,EmployeeName,ClockIn,ClockInDate,ClockInTime,ClockOut,ClockOutDate,ClockOutTime,CashTakenIn,CashPutInSafe")] EmployeeShiftViewModel employeeShiftViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 0) { return Redirect("~/NotAuthorized/Index"); }
            employeeShiftViewModel.ClockIn = DateTime.Now;
            employeeShiftViewModel.ClockInDate = DateTime.Now;
            employeeShiftViewModel.ClockOutDate = DateTime.Now;
            employeeShiftViewModel.EmployeeId = int.Parse(Session["Id"].ToString());
            if (ModelState.IsValid)
            {
                _services.CreateNewEmployeeShift(employeeShiftViewModel, Session["Email"].ToString());
                return RedirectToAction("Index");
            }

            return View(employeeShiftViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 0) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeShiftViewModel employeeShiftViewModel = _services.FindEntryById(id.Value);
            if (employeeShiftViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeShiftViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,EmployeeName,ClockIn,ClockInDate,ClockInTime,ClockOut,ClockOutDate,ClockOutTime,CashTakenIn,CashPutInSafe")] EmployeeShiftViewModel employeeShiftViewModel)
        {
            var old = _services.FindEntryById(employeeShiftViewModel.Id);

            employeeShiftViewModel.Id = old.Id;
            employeeShiftViewModel.EmployeeId = old.EmployeeId;
            employeeShiftViewModel.ClockIn = old.ClockIn;
            employeeShiftViewModel.ClockOut = DateTime.Now;
            employeeShiftViewModel.CashTakenIn = old.CashTakenIn;
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 0) { return Redirect("~/NotAuthorized/Index"); }
            _services.PostChangesForEdit(employeeShiftViewModel);
            return RedirectToAction("Index");

        }
    }
}

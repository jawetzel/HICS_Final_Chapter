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
using HotelIntegratedComputerSystems.Services.Employee;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class EmployeeShiftViewModelsController : BaseController
    {
        private ClockInServices _services = new ClockInServices();

        public ActionResult Index()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetShiftsForEmployee(Session["Name"].ToString()));
        }


        // GET: EmployeeShiftViewModels/Create
        public ActionResult Create()
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }

            return View();
        }

        // POST: EmployeeShiftViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,EmployeeName,ClockIn,ClockInDate,ClockInTime,ClockOut,ClockOutDate,ClockOutTime,CashTakenIn,CashPutInSafe")] EmployeeShiftViewModel employeeShiftViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }

            if (ModelState.IsValid)
            {
                _services.CreateNewEmployeeShift(employeeShiftViewModel, Session["Email"].ToString());
                return RedirectToAction("Index");
            }

            return View(employeeShiftViewModel);
        }

        // GET: EmployeeShiftViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }

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

        // POST: EmployeeShiftViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,EmployeeName,ClockIn,ClockInDate,ClockInTime,ClockOut,ClockOutDate,ClockOutTime,CashTakenIn,CashPutInSafe")] EmployeeShiftViewModel employeeShiftViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2 || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }

            if (ModelState.IsValid)
            {
                _services.PostChangesForEdit(employeeShiftViewModel);
                return RedirectToAction("Index");
            }
            return View(employeeShiftViewModel);
        }
    }
}

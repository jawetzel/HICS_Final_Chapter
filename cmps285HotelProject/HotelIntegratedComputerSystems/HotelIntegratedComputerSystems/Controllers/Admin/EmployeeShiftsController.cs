using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.Admin;
using HotelIntegratedComputerSystems.Controllers.Default;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class EmployeeShiftsController : BaseController
    {
        private readonly EmployeeShiftServices _services = new EmployeeShiftServices();

        public ActionResult Index()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_services.GetEmployeeShiftList());
        }

        public ActionResult Create()
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            ViewBag.EmployeeId = new SelectList(Db.Employees, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,EmployeeName,ClockInDate,ClockInTime,ClockOutDate,ClockOutTime,CashTakenIn,CashPutInSafe")] EmployeeShiftViewModel employeeShiftViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            employeeShiftViewModel.ClockIn = employeeShiftViewModel.ClockInDate.Date + employeeShiftViewModel.ClockInTime.TimeOfDay;
            employeeShiftViewModel.ClockInDate = employeeShiftViewModel.ClockInDate.Date + employeeShiftViewModel.ClockInTime.TimeOfDay;
            employeeShiftViewModel.ClockOutDate = employeeShiftViewModel.ClockOutDate.Value.Date + employeeShiftViewModel.ClockOutTime.Value.TimeOfDay;
            if (!ModelState.IsValid) return View(employeeShiftViewModel);
            _services.CreateNewEmployeeShift(employeeShiftViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.EmployeeId = new SelectList(Db.Employees, "Id", "Name");
            var employeeShiftViewModel = _services.FindEntryById(id.Value);

            
            if (employeeShiftViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeShiftViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,EmployeeName,ClockIn,ClockOut,CashTakenIn,CashPutInSafe")] EmployeeShiftViewModel employeeShiftViewModel)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            employeeShiftViewModel.ClockInDate = employeeShiftViewModel.ClockInDate.Date + employeeShiftViewModel.ClockInTime.TimeOfDay;
            employeeShiftViewModel.ClockOutDate = employeeShiftViewModel.ClockOutDate.Value.Date + employeeShiftViewModel.ClockOutTime.Value.TimeOfDay;
            if (!ModelState.IsValid) return View(employeeShiftViewModel);
            _services.PostChangesForEdit(employeeShiftViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (GoogleAccount.TypeId < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeShiftViewModel = _services.FindEntryById(id.Value);
            employeeShiftViewModel.ClockInTime = employeeShiftViewModel.ClockInDate;
            employeeShiftViewModel.ClockOutTime = employeeShiftViewModel.ClockOutDate;
            if (employeeShiftViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeShiftViewModel);
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

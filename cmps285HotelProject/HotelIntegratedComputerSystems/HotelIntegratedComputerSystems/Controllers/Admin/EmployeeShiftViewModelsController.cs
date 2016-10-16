using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class EmployeeShiftViewModelsController : BaseController
    {
        private readonly EmployeeShiftServices _services = new EmployeeShiftServices();

        public ActionResult Index()
        {
            return View(_services.GetEmployeeShiftList());
        }

        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(Db.Employees, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,EmployeeName,ClockIn,ClockOut,CashTakenIn,CashPutInSafe")] EmployeeShiftViewModel employeeShiftViewModel)
        {
            if (!ModelState.IsValid) return View(employeeShiftViewModel);
            _services.CreateNewEmployeeShift(employeeShiftViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            if (!ModelState.IsValid) return View(employeeShiftViewModel);
            _services.PostChangesForEdit(employeeShiftViewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeShiftViewModel = _services.FindEntryById(id.Value);
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
            _services.DeleteEntry(id);
            return RedirectToAction("Index");
        }
    }
}

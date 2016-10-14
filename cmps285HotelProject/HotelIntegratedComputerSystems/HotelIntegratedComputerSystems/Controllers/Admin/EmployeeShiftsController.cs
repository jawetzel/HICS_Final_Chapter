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

namespace HotelIntegratedComputerSystems.Controllers.Employees
{
    public class EmployeeShiftsController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: EmployeeShifts
        public async Task<ActionResult> Index()
        {
            var employeeShifts = _db.EmployeeShifts.Include(e => e.Employee);
            return View(await employeeShifts.ToListAsync());
        }

        // GET: EmployeeShifts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeShift = await _db.EmployeeShifts.FindAsync(id);
            if (employeeShift == null)
            {
                return HttpNotFound();
            }
            return View(employeeShift);
        }

        // GET: EmployeeShifts/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Email");
            return View();
        }

        // POST: EmployeeShifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EmployeeId,ClockIn,ClockOut,CashTakeIn,CashPutInSafe")] EmployeeShift employeeShift)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeeShifts.Add(employeeShift);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Email", employeeShift.EmployeeId);
            return View(employeeShift);
        }

        // GET: EmployeeShifts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeShift = await _db.EmployeeShifts.FindAsync(id);
            if (employeeShift == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Email", employeeShift.EmployeeId);
            return View(employeeShift);
        }

        // POST: EmployeeShifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EmployeeId,ClockIn,ClockOut,CashTakeIn,CashPutInSafe")] EmployeeShift employeeShift)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employeeShift).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(_db.Employees, "Id", "Email", employeeShift.EmployeeId);
            return View(employeeShift);
        }

        // GET: EmployeeShifts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeShift = await _db.EmployeeShifts.FindAsync(id);
            if (employeeShift == null)
            {
                return HttpNotFound();
            }
            return View(employeeShift);
        }

        // POST: EmployeeShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var employeeShift = await _db.EmployeeShifts.FindAsync(id);
            _db.EmployeeShifts.Remove(employeeShift);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

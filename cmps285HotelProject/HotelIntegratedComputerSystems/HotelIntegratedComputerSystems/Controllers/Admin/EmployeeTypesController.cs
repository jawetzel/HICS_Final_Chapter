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

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class EmployeeTypesController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: EmployeeTypes
        public async Task<ActionResult> Index()
        {
            var employeeTypes = _db.EmployeeTypes.Include(e => e.SecurityRank);
            return View(await employeeTypes.ToListAsync());
        }

        // GET: EmployeeTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeType = await _db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Create
        public ActionResult Create()
        {
            ViewBag.SecurityRankId = new SelectList(_db.SecurityRanks, "Id", "AccessLevelDescription");
            return View();
        }

        // POST: EmployeeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SecurityRankId,Title,PayRate")] EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeeTypes.Add(employeeType);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SecurityRankId = new SelectList(_db.SecurityRanks, "Id", "AccessLevelDescription", employeeType.SecurityRankId);
            return View(employeeType);
        }

        // GET: EmployeeTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeType = await _db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            ViewBag.SecurityRankId = new SelectList(_db.SecurityRanks, "Id", "AccessLevelDescription", employeeType.SecurityRankId);
            return View(employeeType);
        }

        // POST: EmployeeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SecurityRankId,Title,PayRate")] EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employeeType).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SecurityRankId = new SelectList(_db.SecurityRanks, "Id", "AccessLevelDescription", employeeType.SecurityRankId);
            return View(employeeType);
        }

        // GET: EmployeeTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeType = await _db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(employeeType);
        }

        // POST: EmployeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var employeeType = await _db.EmployeeTypes.FindAsync(id);
            _db.EmployeeTypes.Remove(employeeType);
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

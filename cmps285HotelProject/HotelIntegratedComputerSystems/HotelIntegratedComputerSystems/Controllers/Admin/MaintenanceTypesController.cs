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
    public class MaintenanceTypesController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: MaintenanceTypes
        public async Task<ActionResult> Index()
        {
            return View(await _db.MaintenanceTypes.ToListAsync());
        }

        // GET: MaintenanceTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceTypes = await _db.MaintenanceTypes.FindAsync(id);
            if (maintenanceTypes == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceTypes);
        }

        // GET: MaintenanceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type")] MaintenanceTypes maintenanceTypes)
        {
            if (!ModelState.IsValid) return View(maintenanceTypes);
            _db.MaintenanceTypes.Add(maintenanceTypes);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: MaintenanceTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceTypes = await _db.MaintenanceTypes.FindAsync(id);
            if (maintenanceTypes == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceTypes);
        }

        // POST: MaintenanceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type")] MaintenanceTypes maintenanceTypes)
        {
            if (!ModelState.IsValid) return View(maintenanceTypes);
            _db.Entry(maintenanceTypes).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: MaintenanceTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceTypes = await _db.MaintenanceTypes.FindAsync(id);
            if (maintenanceTypes == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceTypes);
        }

        // POST: MaintenanceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var maintenanceTypes = await _db.MaintenanceTypes.FindAsync(id);
            _db.MaintenanceTypes.Remove(maintenanceTypes);
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

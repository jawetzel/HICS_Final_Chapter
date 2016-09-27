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
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: MaintenanceTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.MaintenanceTypes.ToListAsync());
        }

        // GET: MaintenanceTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceTypes maintenanceTypes = await db.MaintenanceTypes.FindAsync(id);
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
            if (ModelState.IsValid)
            {
                db.MaintenanceTypes.Add(maintenanceTypes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maintenanceTypes);
        }

        // GET: MaintenanceTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceTypes maintenanceTypes = await db.MaintenanceTypes.FindAsync(id);
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
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceTypes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maintenanceTypes);
        }

        // GET: MaintenanceTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceTypes maintenanceTypes = await db.MaintenanceTypes.FindAsync(id);
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
            MaintenanceTypes maintenanceTypes = await db.MaintenanceTypes.FindAsync(id);
            db.MaintenanceTypes.Remove(maintenanceTypes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

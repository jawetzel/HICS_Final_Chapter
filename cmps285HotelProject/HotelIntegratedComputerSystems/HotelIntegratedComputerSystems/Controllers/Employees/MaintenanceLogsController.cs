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
    public class MaintenanceLogsController : Controller
    {
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: MaintenanceLogs
        public async Task<ActionResult> Index()
        {
            var maintenanceLogs = db.MaintenanceLogs.Include(m => m.Room).Include(m => m.MaintenanceType);
            return View(await maintenanceLogs.ToListAsync());
        }

        // GET: MaintenanceLogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceLogs maintenanceLogs = await db.MaintenanceLogs.FindAsync(id);
            if (maintenanceLogs == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Create
        public ActionResult Create()
        {
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus");
            ViewBag.MaintenanceTypesId = new SelectList(db.MaintenanceTypes, "Id", "Type");
            return View();
        }

        // POST: MaintenanceLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RoomId,Description,Date,MaintenanceTypesId")] MaintenanceLogs maintenanceLogs)
        {
            if (ModelState.IsValid)
            {
                db.MaintenanceLogs.Add(maintenanceLogs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", maintenanceLogs.RoomId);
            ViewBag.MaintenanceTypesId = new SelectList(db.MaintenanceTypes, "Id", "Type", maintenanceLogs.MaintenanceTypesId);
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceLogs maintenanceLogs = await db.MaintenanceLogs.FindAsync(id);
            if (maintenanceLogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", maintenanceLogs.RoomId);
            ViewBag.MaintenanceTypesId = new SelectList(db.MaintenanceTypes, "Id", "Type", maintenanceLogs.MaintenanceTypesId);
            return View(maintenanceLogs);
        }

        // POST: MaintenanceLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RoomId,Description,Date,MaintenanceTypesId")] MaintenanceLogs maintenanceLogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceLogs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", maintenanceLogs.RoomId);
            ViewBag.MaintenanceTypesId = new SelectList(db.MaintenanceTypes, "Id", "Type", maintenanceLogs.MaintenanceTypesId);
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceLogs maintenanceLogs = await db.MaintenanceLogs.FindAsync(id);
            if (maintenanceLogs == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceLogs);
        }

        // POST: MaintenanceLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MaintenanceLogs maintenanceLogs = await db.MaintenanceLogs.FindAsync(id);
            db.MaintenanceLogs.Remove(maintenanceLogs);
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

using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;

namespace HotelIntegratedComputerSystems.Controllers.Admin
{
    public class MaintenanceLogsController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: MaintenanceLogs
        public async Task<ActionResult> Index()
        {
            var maintenanceLogs = _db.MaintenanceLogs.Include(m => m.Room).Include(m => m.MaintenanceType);
            return View(await maintenanceLogs.ToListAsync());
        }

        // GET: MaintenanceLogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceLogs = await _db.MaintenanceLogs.FindAsync(id);
            if (maintenanceLogs == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Create
        public ActionResult Create()
        {
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id");
            ViewBag.MaintenanceTypesId = new SelectList(_db.MaintenanceTypes, "Id", "Type");
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
                _db.MaintenanceLogs.Add(maintenanceLogs);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id", maintenanceLogs.RoomId);
            ViewBag.MaintenanceTypesId = new SelectList(_db.MaintenanceTypes, "Id", "Type", maintenanceLogs.MaintenanceTypesId);
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceLogs = await _db.MaintenanceLogs.FindAsync(id);
            if (maintenanceLogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id", maintenanceLogs.RoomId);
            ViewBag.MaintenanceTypesId = new SelectList(_db.MaintenanceTypes, "Id", "Type", maintenanceLogs.MaintenanceTypesId);
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
                _db.Entry(maintenanceLogs).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id", maintenanceLogs.RoomId);
            ViewBag.MaintenanceTypesId = new SelectList(_db.MaintenanceTypes, "Id", "Type", maintenanceLogs.MaintenanceTypesId);
            return View(maintenanceLogs);
        }

        // GET: MaintenanceLogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maintenanceLogs = await _db.MaintenanceLogs.FindAsync(id);
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
            var maintenanceLogs = await _db.MaintenanceLogs.FindAsync(id);
            _db.MaintenanceLogs.Remove(maintenanceLogs);
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

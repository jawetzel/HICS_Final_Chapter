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
    public class RoomStatusController : Controller
    {
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: RoomStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.RoomStatus.ToListAsync());
        }

        // GET: RoomStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomStatus roomStatus = await db.RoomStatus.FindAsync(id);
            if (roomStatus == null)
            {
                return HttpNotFound();
            }
            return View(roomStatus);
        }

        // GET: RoomStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description")] RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                db.RoomStatus.Add(roomStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(roomStatus);
        }

        // GET: RoomStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomStatus roomStatus = await db.RoomStatus.FindAsync(id);
            if (roomStatus == null)
            {
                return HttpNotFound();
            }
            return View(roomStatus);
        }

        // POST: RoomStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description")] RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roomStatus);
        }

        // GET: RoomStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomStatus roomStatus = await db.RoomStatus.FindAsync(id);
            if (roomStatus == null)
            {
                return HttpNotFound();
            }
            return View(roomStatus);
        }

        // POST: RoomStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RoomStatus roomStatus = await db.RoomStatus.FindAsync(id);
            db.RoomStatus.Remove(roomStatus);
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

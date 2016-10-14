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
    public class RoomsController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: Rooms
        public async Task<ActionResult> Index()
        {
            var rooms = _db.Rooms.Include(r => r.Building).Include(r => r.HouseKeepingStatu).Include(r => r.RoomType).Include(r => r.RoomStatus);
            return View(await rooms.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var room = await _db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            ViewBag.BuildingId = new SelectList(_db.Buildings, "Id", "Address");
            ViewBag.HousekeepingStatusId = new SelectList(_db.HouseKeepingStatus, "Id", "CleanStatus");
            ViewBag.RoomTypeId = new SelectList(_db.RoomTypes, "Id", "Bedding");
            ViewBag.RoomStatusId = new SelectList(_db.RoomStatus, "Id", "Description");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BuildingId,RoomTypeId,HousekeepingStatusId,FloorNumber,RoomNumber,RoomStatusId")] Room room)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Add(room);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingId = new SelectList(_db.Buildings, "Id", "Address", room.BuildingId);
            ViewBag.HousekeepingStatusId = new SelectList(_db.HouseKeepingStatus, "Id", "CleanStatus", room.HousekeepingStatusId);
            ViewBag.RoomTypeId = new SelectList(_db.RoomTypes, "Id", "Bedding", room.RoomTypeId);
            ViewBag.RoomStatusId = new SelectList(_db.RoomStatus, "Id", "Description", room.RoomStatusId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var room = await _db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingId = new SelectList(_db.Buildings, "Id", "Address", room.BuildingId);
            ViewBag.HousekeepingStatusId = new SelectList(_db.HouseKeepingStatus, "Id", "CleanStatus", room.HousekeepingStatusId);
            ViewBag.RoomTypeId = new SelectList(_db.RoomTypes, "Id", "Bedding", room.RoomTypeId);
            ViewBag.RoomStatusId = new SelectList(_db.RoomStatus, "Id", "Description", room.RoomStatusId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BuildingId,RoomTypeId,HousekeepingStatusId,FloorNumber,RoomNumber,RoomStatusId")] Room room)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(room).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingId = new SelectList(_db.Buildings, "Id", "Address", room.BuildingId);
            ViewBag.HousekeepingStatusId = new SelectList(_db.HouseKeepingStatus, "Id", "CleanStatus", room.HousekeepingStatusId);
            ViewBag.RoomTypeId = new SelectList(_db.RoomTypes, "Id", "Bedding", room.RoomTypeId);
            ViewBag.RoomStatusId = new SelectList(_db.RoomStatus, "Id", "Description", room.RoomStatusId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var room = await _db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var room = await _db.Rooms.FindAsync(id);
            _db.Rooms.Remove(room);
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

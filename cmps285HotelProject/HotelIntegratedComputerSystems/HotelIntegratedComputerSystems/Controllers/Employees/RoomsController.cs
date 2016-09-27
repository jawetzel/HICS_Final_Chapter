﻿using System;
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
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: Rooms
        public async Task<ActionResult> Index()
        {
            var rooms = db.Rooms.Include(r => r.Building).Include(r => r.HouseKeepingStatu).Include(r => r.RoomType);
            return View(await rooms.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Address");
            ViewBag.HousekeepingStatusId = new SelectList(db.HouseKeepingStatus, "Id", "CleanStatus");
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Bedding");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BuildingId,RoomTypeId,HousekeepingStatusId,FloorNumber,RoomNumber,RoomStatus")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Address", room.BuildingId);
            ViewBag.HousekeepingStatusId = new SelectList(db.HouseKeepingStatus, "Id", "CleanStatus", room.HousekeepingStatusId);
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Bedding", room.RoomTypeId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Address", room.BuildingId);
            ViewBag.HousekeepingStatusId = new SelectList(db.HouseKeepingStatus, "Id", "CleanStatus", room.HousekeepingStatusId);
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Bedding", room.RoomTypeId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BuildingId,RoomTypeId,HousekeepingStatusId,FloorNumber,RoomNumber,RoomStatus")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Address", room.BuildingId);
            ViewBag.HousekeepingStatusId = new SelectList(db.HouseKeepingStatus, "Id", "CleanStatus", room.HousekeepingStatusId);
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Bedding", room.RoomTypeId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
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
            Room room = await db.Rooms.FindAsync(id);
            db.Rooms.Remove(room);
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

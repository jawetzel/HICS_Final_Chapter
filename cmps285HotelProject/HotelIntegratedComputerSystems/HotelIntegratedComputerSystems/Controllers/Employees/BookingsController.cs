﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Services.Employee;

namespace HotelIntegratedComputerSystems.Controllers.Employees
{
    public class BookingsController : BaseController
    {
        private readonly BookingServices _service = new BookingServices();

        // GET: Bookings
        public ActionResult Index()
        {
            return View(_service.GetBookingList());
        }


        // GET: Bookings/Create
        public ActionResult Create()
        {
            BookingViewModel newBooking = new BookingViewModel();
            newBooking.customers = _service.loadCustomerNames();
            return View(newBooking);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,RoomId,StartDate,EndDate,VolumeAdults,VolumeChildren")] BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid) return View(bookingViewModel);
            _service.CreateNewBooking(bookingViewModel);

            return RedirectToAction("Index");
        }

        //GET: Bookings/Edit/5
        public ActionResult Edit(int id)
        {
            var editBooking = _service.FindBookingById(id);
            editBooking.customers = _service.loadCustomerNames();
            if (editBooking == null)
            {
                return HttpNotFound();
            }
            return View(editBooking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,RoomId,StartDate,EndDate,VolumeAdults,VolumeChildren")] BookingViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {   
                _service.PostChangesForEdit(bookingViewModel);
                return RedirectToAction("Index");
            }
            return View(bookingViewModel);
        }

        //    // GET: Bookings/Delete/5
        //    public async Task<ActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        var booking = await _db.Bookings.FindAsync(id);
        //        if (booking == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(booking);
        //    }

        //    // POST: Bookings/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<ActionResult> DeleteConfirmed(int id)
        //    {
        //        var booking = await _db.Bookings.FindAsync(id);
        //        _db.Bookings.Remove(booking);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            _db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}

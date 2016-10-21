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
    public class ExpensesController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: Expenses
        public async Task<ActionResult> Index()
        {
            var expenses = _db.Expenses1.Include(e => e.ExpenseType).Include(e => e.Room).Include(e => e.Booking);
            return View(await expenses.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expense = await _db.Expenses1.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseTypeId = new SelectList(_db.ExpenseTypes, "Id", "Type");
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id");
            ViewBag.BookingId = new SelectList(_db.Bookings, "Id", "Id");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RoomId,ExpenseTypeId,BookingId")] Expenses expense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses1.Add(expense);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseTypeId = new SelectList(_db.ExpenseTypes, "Id", "Type", expense.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id", expense.RoomId);
            ViewBag.BookingId = new SelectList(_db.Bookings, "Id", "Id", expense.BookingId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expense = await _db.Expenses1.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseTypeId = new SelectList(_db.ExpenseTypes, "Id", "Type", expense.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id", expense.RoomId);
            ViewBag.BookingId = new SelectList(_db.Bookings, "Id", "Id", expense.BookingId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RoomId,ExpenseTypeId,BookingId")] Expenses expense)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(expense).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseTypeId = new SelectList(_db.ExpenseTypes, "Id", "Type", expense.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Id", expense.RoomId);
            ViewBag.BookingId = new SelectList(_db.Bookings, "Id", "Id", expense.BookingId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expense = await _db.Expenses1.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var expense = await _db.Expenses1.FindAsync(id);
            _db.Expenses1.Remove(expense);
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

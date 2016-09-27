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
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: Expenses
        public async Task<ActionResult> Index()
        {
            var expenses = db.Expenses.Include(e => e.ExpenseType).Include(e => e.Room).Include(e => e.Booking);
            return View(await expenses.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type");
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus");
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "Id");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RoomId,ExpenseTypeId,BookingId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type", expense.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", expense.RoomId);
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "Id", expense.BookingId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type", expense.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", expense.RoomId);
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "Id", expense.BookingId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RoomId,ExpenseTypeId,BookingId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type", expense.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", expense.RoomId);
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "Id", expense.BookingId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
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
            Expense expense = await db.Expenses.FindAsync(id);
            db.Expenses.Remove(expense);
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

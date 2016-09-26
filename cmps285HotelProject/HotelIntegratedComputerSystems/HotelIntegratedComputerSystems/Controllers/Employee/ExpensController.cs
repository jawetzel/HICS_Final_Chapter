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

namespace HotelIntegratedComputerSystems.Controllers
{
    public class ExpensController : Controller
    {
        private HicsTestDbEntities db = new HicsTestDbEntities();

        // GET: Expens
        public async Task<ActionResult> Index()
        {
            var expenses = db.Expenses.Include(e => e.ExpenseType).Include(e => e.Room);
            return View(await expenses.ToListAsync());
        }

        // GET: Expens/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expens expens = await db.Expenses.FindAsync(id);
            if (expens == null)
            {
                return HttpNotFound();
            }
            return View(expens);
        }

        // GET: Expens/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type");
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus");
            return View();
        }

        // POST: Expens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RoomId,ExpenseTypeId")] Expens expens)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expens);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type", expens.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", expens.RoomId);
            return View(expens);
        }

        // GET: Expens/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expens expens = await db.Expenses.FindAsync(id);
            if (expens == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type", expens.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", expens.RoomId);
            return View(expens);
        }

        // POST: Expens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RoomId,ExpenseTypeId")] Expens expens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expens).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseTypeId = new SelectList(db.ExpenseTypes, "Id", "Type", expens.ExpenseTypeId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomStatus", expens.RoomId);
            return View(expens);
        }

        // GET: Expens/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expens expens = await db.Expenses.FindAsync(id);
            if (expens == null)
            {
                return HttpNotFound();
            }
            return View(expens);
        }

        // POST: Expens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Expens expens = await db.Expenses.FindAsync(id);
            db.Expenses.Remove(expens);
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

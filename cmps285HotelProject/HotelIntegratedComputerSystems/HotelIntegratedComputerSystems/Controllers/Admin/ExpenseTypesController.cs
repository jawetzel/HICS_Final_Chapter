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
    public class ExpenseTypesController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: ExpenseTypes
        public async Task<ActionResult> Index()
        {
            return View(await _db.ExpenseTypes.ToListAsync());
        }

        // GET: ExpenseTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseType = await _db.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return HttpNotFound();
            }
            return View(expenseType);
        }

        // GET: ExpenseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type,Description,Ammount")] ExpenseType expenseType)
        {
            if (!ModelState.IsValid) return View(expenseType);
            _db.ExpenseTypes.Add(expenseType);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: ExpenseTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseType = await _db.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return HttpNotFound();
            }
            return View(expenseType);
        }

        // POST: ExpenseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type,Description,Ammount")] ExpenseType expenseType)
        {
            if (!ModelState.IsValid) return View(expenseType);
            _db.Entry(expenseType).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: ExpenseTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseType = await _db.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return HttpNotFound();
            }
            return View(expenseType);
        }

        // POST: ExpenseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var expenseType = await _db.ExpenseTypes.FindAsync(id);
            _db.ExpenseTypes.Remove(expenseType);
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

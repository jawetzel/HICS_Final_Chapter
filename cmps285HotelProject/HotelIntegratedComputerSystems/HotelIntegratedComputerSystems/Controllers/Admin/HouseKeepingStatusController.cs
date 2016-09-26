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
    public class HouseKeepingStatusController : Controller
    {
        private HicsTestDbEntities db = new HicsTestDbEntities();

        // GET: HouseKeepingStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.HouseKeepingStatus.ToListAsync());
        }

        // GET: HouseKeepingStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseKeepingStatu houseKeepingStatu = await db.HouseKeepingStatus.FindAsync(id);
            if (houseKeepingStatu == null)
            {
                return HttpNotFound();
            }
            return View(houseKeepingStatu);
        }

        // GET: HouseKeepingStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseKeepingStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CleanStatus")] HouseKeepingStatu houseKeepingStatu)
        {
            if (ModelState.IsValid)
            {
                db.HouseKeepingStatus.Add(houseKeepingStatu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(houseKeepingStatu);
        }

        // GET: HouseKeepingStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseKeepingStatu houseKeepingStatu = await db.HouseKeepingStatus.FindAsync(id);
            if (houseKeepingStatu == null)
            {
                return HttpNotFound();
            }
            return View(houseKeepingStatu);
        }

        // POST: HouseKeepingStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CleanStatus")] HouseKeepingStatu houseKeepingStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseKeepingStatu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(houseKeepingStatu);
        }

        // GET: HouseKeepingStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseKeepingStatu houseKeepingStatu = await db.HouseKeepingStatus.FindAsync(id);
            if (houseKeepingStatu == null)
            {
                return HttpNotFound();
            }
            return View(houseKeepingStatu);
        }

        // POST: HouseKeepingStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HouseKeepingStatu houseKeepingStatu = await db.HouseKeepingStatus.FindAsync(id);
            db.HouseKeepingStatus.Remove(houseKeepingStatu);
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

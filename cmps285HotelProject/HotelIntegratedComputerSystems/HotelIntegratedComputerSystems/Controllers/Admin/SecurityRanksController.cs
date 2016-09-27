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
    public class SecurityRanksController : Controller
    {
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: SecurityRanks
        public async Task<ActionResult> Index()
        {
            return View(await db.SecurityRanks.ToListAsync());
        }

        // GET: SecurityRanks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityRank securityRank = await db.SecurityRanks.FindAsync(id);
            if (securityRank == null)
            {
                return HttpNotFound();
            }
            return View(securityRank);
        }

        // GET: SecurityRanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityRanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SiteAccessLevel,AccessLevelDescription")] SecurityRank securityRank)
        {
            if (ModelState.IsValid)
            {
                db.SecurityRanks.Add(securityRank);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(securityRank);
        }

        // GET: SecurityRanks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityRank securityRank = await db.SecurityRanks.FindAsync(id);
            if (securityRank == null)
            {
                return HttpNotFound();
            }
            return View(securityRank);
        }

        // POST: SecurityRanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SiteAccessLevel,AccessLevelDescription")] SecurityRank securityRank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityRank).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(securityRank);
        }

        // GET: SecurityRanks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityRank securityRank = await db.SecurityRanks.FindAsync(id);
            if (securityRank == null)
            {
                return HttpNotFound();
            }
            return View(securityRank);
        }

        // POST: SecurityRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SecurityRank securityRank = await db.SecurityRanks.FindAsync(id);
            db.SecurityRanks.Remove(securityRank);
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

using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;

namespace HotelIntegratedComputerSystems.Controllers.Unaccessible
{
    public class HouseKeepingStatusController : Controller
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();

        // GET: HouseKeepingStatus
        public async Task<ActionResult> Index()
        {
            return View(await _db.HouseKeepingStatus.ToListAsync());
        }

        // GET: HouseKeepingStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var houseKeepingStatu = await _db.HouseKeepingStatus.FindAsync(id);
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
            if (!ModelState.IsValid) return View(houseKeepingStatu);
            _db.HouseKeepingStatus.Add(houseKeepingStatu);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: HouseKeepingStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var houseKeepingStatu = await _db.HouseKeepingStatus.FindAsync(id);
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
                _db.Entry(houseKeepingStatu).State = EntityState.Modified;
                await _db.SaveChangesAsync();
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
            var houseKeepingStatu = await _db.HouseKeepingStatus.FindAsync(id);
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
            var houseKeepingStatu = await _db.HouseKeepingStatus.FindAsync(id);
            _db.HouseKeepingStatus.Remove(houseKeepingStatu);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Employees;

namespace HotelIntegratedComputerSystems.Controllers
{
    public class CustomersViewModelsController : Controller
    {
        private HicsTestDbEntities1 db = new HicsTestDbEntities1();

        // GET: CustomersViewModels
        public ActionResult Index()
        {
            return View(db.CustomersViewModels.ToList());
        }

        // GET: CustomersViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersViewModel customersViewModel = db.CustomersViewModels.Find(id);
            if (customersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customersViewModel);
        }

        // GET: CustomersViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (ModelState.IsValid)
            {
                db.CustomersViewModels.Add(customersViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customersViewModel);
        }

        // GET: CustomersViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersViewModel customersViewModel = db.CustomersViewModels.Find(id);
            if (customersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customersViewModel);
        }

        // POST: CustomersViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customersViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customersViewModel);
        }

        // GET: CustomersViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomersViewModel customersViewModel = db.CustomersViewModels.Find(id);
            if (customersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customersViewModel);
        }

        // POST: CustomersViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomersViewModel customersViewModel = db.CustomersViewModels.Find(id);
            db.CustomersViewModels.Remove(customersViewModel);
            db.SaveChanges();
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

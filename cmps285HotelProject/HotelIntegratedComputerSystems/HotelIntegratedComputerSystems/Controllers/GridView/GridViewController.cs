using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Services.Employee;
using HotelIntegratedComputerSystems.Services.GridViewService;

namespace HotelIntegratedComputerSystems.Controllers.GridView
{
    public class GridViewController : BaseController
    {
        private  readonly GridViewServices _service = new GridViewServices();
        private readonly CustomerServices _customerService = new CustomerServices();

        // GET: GridView
        public ActionResult Index()
        {
            return View(_service.GetGridViewRooms(DateTime.Today, DateTime.Today.AddDays(6)));
        }

        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate)
        {
            return View(_service.GetGridViewRooms(startDate, endDate));

        }

        // GET: GridView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //public ActionResult Details()
        //{
        //    return View();
        //}

        // GET: GridView/Create
        public ActionResult Create()
        {
            var actionResult = View();
            return actionResult;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (!ModelState.IsValid) return View(customersViewModel);
            _customerService.CreateNewCustomer(customersViewModel);
            return RedirectToAction("Index");
        }

        // POST: GridView/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GridView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GridView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GridView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GridView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

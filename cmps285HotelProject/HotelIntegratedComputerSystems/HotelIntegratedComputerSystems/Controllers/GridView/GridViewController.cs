using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Services.Employee;
using HotelIntegratedComputerSystems.Services.GridViewService;
using HotelIntegratedComputerSystems.Controllers.Default;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Controllers.GridView
{
    public class GridViewController : BaseController
    {
        private  readonly GridViewServices _service = new GridViewServices();
        private readonly CustomerServices _customerService = new CustomerServices();
        private readonly BookingServices _bookingservice = new BookingServices();
        private readonly RoomServices _roomServices = new RoomServices();

        // GET: GridView
        public ActionResult Index()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            return View(_service.GetGridViewRooms(DateTime.Today, DateTime.Today.AddDays(6)));
        }

        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            return View(_service.GetGridViewRooms(startDate, endDate));

        }

        // GET: GridView/Details/5
        public ActionResult Details(int id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            return View();
        }

        //public ActionResult Details()
        //{
        //    return View();
        //}

        // GET: GridView/Create
        public ActionResult NewCust()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            var actionResult = View();
            return actionResult;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCust([Bind(Include = "Id,Name,Address,Phone,Email")] CustomersViewModel customersViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(customersViewModel);
            _customerService.CreateNewCustomer(customersViewModel);
            return RedirectToAction("Index");
        }

        // GET: Bookings/Create
        public ActionResult NewBook()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            BookingViewModel newBooking = new BookingViewModel();
            newBooking.customers = _bookingservice.loadCustomerNames();
            newBooking.RoomsList = _roomServices.GetRoomList();
            return View(newBooking);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewBook([Bind(Include = "Id,CustomerId,RoomId,StartDate,EndDate,VolumeAdults,VolumeChildren,RoomNumber,FloorNumber,BuildingName,customers")] BookingViewModel bookingViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return View(bookingViewModel);
            _bookingservice.CreateNewBooking(bookingViewModel);

            return RedirectToAction("Index");
        }

        // POST: GridView/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }

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
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            return View();
        }

        // POST: GridView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
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
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
            return View();
        }

        // POST: GridView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 3) { return Redirect("~/NotAuthorized/Index"); }
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

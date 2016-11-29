using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Services.Employee;
using HotelIntegratedComputerSystems.Services.Admin;
using HotelIntegratedComputerSystems.Controllers.Default;


namespace HotelIntegratedComputerSystems.Controllers.Employees
{
    public class TransactionsController : BaseController
    {
        private readonly TransactionsServices _transService = new TransactionsServices();
        private readonly BookingServices _bookingService = new BookingServices();
        private readonly ExpensesServices _expenseService = new ExpensesServices();
        private readonly RoomServices _roomServices = new RoomServices();

        // GET: Bookings
        public ActionResult Index()
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            return View(_bookingService.FindActiveBookings());
        }

        public ActionResult CheckIn(int id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }

            BookingViewModel bookingCheckIn = _bookingService.FindBookingById(id);
          
            return View(bookingCheckIn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckIn([Bind(Include = "Id,CustomerId,RoomId,StartDate,EndDate,VolumeAdults,VolumeChildren,RoomNumber,FloorNumber,BuildingName,customers")] BookingViewModel bookingViewModel)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return Redirect("Index");
            _transService.PostCheckIn(bookingViewModel);

            return RedirectToAction("Index");
        }

        public ActionResult CheckOut(int id)
        {
            if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
            TransactionsViewModel bookingCheckOut = new TransactionsViewModel();
            bookingCheckOut.booking = _bookingService.FindBookingById(id);
            //if (bookingCheckOut.CheckedInDate == null) { return Redirect("Index"); }
            bookingCheckOut.Expense = _expenseService.GetExpenseByBookingId(bookingCheckOut.booking);

            return View(bookingCheckOut);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CheckOut([Bind(Include = "Id,CustomerId,RoomId,StartDate,EndDate,VolumeAdults,VolumeChildren")] BookingViewModel bookingViewModel)
        //{
        //    if (Session["TypeId"] == null || int.Parse(Session["TypeId"].ToString()) < 4) { return Redirect("~/NotAuthorized/Index"); }
        //    if (ModelState.IsValid)
        //    {
                
        //    }
        //    return View(bookingViewModel);
        //}
    }
}
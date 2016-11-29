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
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            return View(_bookingService.FindActiveBookings());
        }

        public ActionResult CheckIn(int id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }

            BookingViewModel bookingCheckIn = _bookingService.FindBookingById(id);
          
            return View(bookingCheckIn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckIn([Bind(Include = "Id,CustomerId,RoomId,StartDate,EndDate,VolumeAdults,VolumeChildren,RoomNumber,FloorNumber,BuildingName,customers")] BookingViewModel bookingViewModel)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            if (!ModelState.IsValid) return Redirect("Index");
            _transService.PostCheckIn(bookingViewModel);

            return RedirectToAction("Index");
        }

        public ActionResult CheckOut(int id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            BookingViewModel bookingCheckOut = new BookingViewModel();
            bookingCheckOut = _bookingService.FindBookingById(id);
            bookingCheckOut.Expense = _expenseService.GetExpenseByBookingId(bookingCheckOut);
            bookingCheckOut.totalSum = _transService.tallySum(bookingCheckOut);
            return View(bookingCheckOut);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut([Bind(Include = "Id,CustomerId,RoomId,StartDate,EndDate,VolumeAdults,VolumeChildren,RoomNumber,FloorNumber,BuildingName,Expense,totalSum,booking,CheckedInDate")]  BookingViewModel bookingCheckOut)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 1 || int.Parse(Session["AccessLevel"].ToString()) == 2) { return Redirect("~/NotAuthorized/Index"); }
            BookingViewModel bookingViewModel = bookingCheckOut;
            _transService.PostCheckOut(bookingViewModel);
            return RedirectToAction("Index");
        }
    }
}
    
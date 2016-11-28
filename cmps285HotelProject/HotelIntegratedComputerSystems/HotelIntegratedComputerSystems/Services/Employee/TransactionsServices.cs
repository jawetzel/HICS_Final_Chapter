using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Services.Employee
{
    public class TransactionsServices : BaseServices
    {
        public readonly CustomerServices _customerServices = new CustomerServices();
        private readonly RoomServices _roomServices = new RoomServices();
        public readonly BookingServices _bookingServices = new BookingServices();

        public void PostCheckIn(BookingViewModel checkInBooking)
        {
            checkInBooking.BookingStatusId = Db.BookingStatus.First(x => x.BookingStatusDescription == "Checked In").Id;
            checkInBooking.RoomId = Db.Rooms.First(x => x.Building.BuildingName == checkInBooking.BuildingName && x.FloorNumber == checkInBooking.FloorNumber && x.RoomNumber == checkInBooking.RoomNumber).Id;

            Db.Entry(new Booking()
            {
                Id = checkInBooking.Id,
                CustomerId = checkInBooking.CustomerId,
                RoomId = checkInBooking.RoomId,
                StartDate = checkInBooking.StartDate,
                EndDate = checkInBooking.EndDate,
                VolumeAdults = checkInBooking.VolumeAdults,
                VolumeChildren = checkInBooking.VolumeChildren,
                BookingStatusId = checkInBooking.BookingStatusId,
                CheckedInDate = DateTime.Now
            }).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void PostCheckOut(BookingViewModel checkOutBooking)
        {
            checkOutBooking.BookingStatusId = Db.BookingStatus.First(x => x.BookingStatusDescription == "Checked Out").Id;
            checkOutBooking.RoomId = Db.Rooms.First(x => x.Building.BuildingName == checkOutBooking.BuildingName && x.FloorNumber == checkOutBooking.FloorNumber && x.RoomNumber == checkOutBooking.RoomNumber).Id;

            Db.Entry(new Booking()
            {
                Id = checkOutBooking.Id,
                CustomerId = checkOutBooking.CustomerId,
                RoomId = checkOutBooking.RoomId,
                StartDate = checkOutBooking.StartDate,
                EndDate = checkOutBooking.EndDate,
                VolumeAdults = checkOutBooking.VolumeAdults,
                VolumeChildren = checkOutBooking.VolumeChildren,
                BookingStatusId = checkOutBooking.BookingStatusId,
                CheckedInDate = checkOutBooking.CheckedInDate,
                CheckedOutDate = DateTime.Now
            }).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void PostCancel(BookingViewModel checkInBooking)
        {
            checkInBooking.BookingStatusId = Db.BookingStatus.First(x => x.BookingStatusDescription == "Cancelled").Id;
            checkInBooking.RoomId = Db.Rooms.First(x => x.Building.BuildingName == checkInBooking.BuildingName && x.FloorNumber == checkInBooking.FloorNumber && x.RoomNumber == checkInBooking.RoomNumber).Id;

            Db.Entry(new Booking()
            {
                Id = checkInBooking.Id,
                CustomerId = checkInBooking.CustomerId,
                RoomId = checkInBooking.RoomId,
                StartDate = checkInBooking.StartDate,
                EndDate = checkInBooking.EndDate,
                VolumeAdults = checkInBooking.VolumeAdults,
                VolumeChildren = checkInBooking.VolumeChildren,
                BookingStatusId = checkInBooking.BookingStatusId,
                CheckedInDate = checkInBooking.CheckedInDate,
                CheckedOutDate = checkInBooking.CheckedOutDate
            }).State = EntityState.Modified;
            Db.SaveChanges();
        }



        public decimal tallySum(BookingViewModel bookingViewModel)
        {
            List<ExpensesViewModel> bookingExpenses = bookingViewModel.Expense.ToList();
            decimal sum = 0;
            foreach (var expense in bookingExpenses)
            {
                sum += expense.ExpenseTypeAmmount;
            }
            return sum;
        }
    }
}
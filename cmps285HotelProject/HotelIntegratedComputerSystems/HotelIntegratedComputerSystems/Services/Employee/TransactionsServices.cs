using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
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
                CheckedInDate = DateTime.Now,
            }).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void PostCheckOut(BookingViewModel checkInBooking)
        {
            checkInBooking.BookingStatusId = Db.BookingStatus.First(x => x.BookingStatusDescription == "Checked Out").Id;
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



        public void tallySum(TransactionsViewModel transViewModel)
        {
            

        }
    }
}
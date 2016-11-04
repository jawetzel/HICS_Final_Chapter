﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Employees;

namespace HotelIntegratedComputerSystems.Services.Employee
{
    public class BookingServices : BaseServices
    {
        public CustomerServices _customerServices = new CustomerServices();
        public PackageBookings GetBookingList()
        {
            
            var bookingList = from Bookings in Db.Bookings
                           select new BookingViewModel
                           {
                               Id = Bookings.Id,
                               CustomerId = Bookings.CustomerId,
                               CustomerName = Bookings.Customer.Name,
                               RoomId = Bookings.RoomId,
                               RoomNumber = Bookings.Room.RoomNumber,
                               StartDate = Bookings.StartDate,
                               EndDate = Bookings.EndDate,
                               VolumeAdults = Bookings.VolumeAdults,
                               VolumeChildren = Bookings.VolumeChildren,
                               BookingStatusId = Bookings.BookingStatusId,
                               CheckedInDate = Bookings.CheckedInDate,
                               CheckedOutDate = Bookings.CheckedOutDate,
                               BookingStatusDescription = Bookings.BookingStatus.BookingStatusDescription,

                           };
            return new PackageBookings() { BookingList = bookingList.ToList() };
        }

        public void CreateNewBooking(BookingViewModel bookings)
        {

            Db.Bookings.Add(new Booking
            {
                Id = bookings.Id,
                CustomerId = bookings.CustomerId,
                RoomId = bookings.RoomId,
                StartDate = bookings.StartDate,
                EndDate = bookings.EndDate,
                VolumeAdults = bookings.VolumeAdults,
                VolumeChildren = bookings.VolumeChildren,
                BookingStatusId = 1,
                CheckedInDate = bookings.CheckedInDate,
                CheckedOutDate = bookings.CheckedOutDate
            });
            Db.SaveChanges();
        }

        public List<CustomersViewModel> loadCustomerNames()
        {
            var customerList = _customerServices.GetCustomersList();
            return customerList;
        }


        public BookingViewModel FindBookingById(int id)
        {
            var bookingInquired = Db.Bookings.Find(id);

            return new BookingViewModel
            {
                Id = bookingInquired.Id,
                CustomerId = bookingInquired.CustomerId,
                CustomerName = bookingInquired.Customer.Name,
                RoomId = bookingInquired.RoomId,
                RoomNumber = bookingInquired.Room.RoomNumber,
                StartDate = bookingInquired.StartDate,
                EndDate = bookingInquired.EndDate,
                VolumeAdults = bookingInquired.VolumeAdults,
                VolumeChildren = bookingInquired.VolumeChildren,
                BookingStatusId = bookingInquired.BookingStatusId,
                CheckedInDate = bookingInquired.CheckedInDate,
                CheckedOutDate = bookingInquired.CheckedOutDate,
                BookingStatusDescription = bookingInquired.BookingStatus.BookingStatusDescription, } ;
            }

        public void PostChangesForEdit(BookingViewModel editBooking)
        {

            Db.Entry(new Models.Booking()
            {
                Id = editBooking.Id,
                CustomerId = editBooking.CustomerId,
                RoomId = editBooking.RoomId,
                StartDate = editBooking.StartDate,
                EndDate = editBooking.EndDate,
                VolumeAdults = editBooking.VolumeAdults,
                VolumeChildren = editBooking.VolumeChildren,
                BookingStatusId = 1,
                CheckedInDate = editBooking.CheckedInDate,
                CheckedOutDate = editBooking.CheckedOutDate
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void DeleteEntry(int id)
        {
            var foundBooking = Db.Bookings.Find(id);
            Db.Bookings.Remove(foundBooking);
            Db.SaveChanges();
        }

        public bool CheckForDependencys(int id)
        {
            var booking = FindBookingById(id);
            var firstCheck = Db.Customers.FirstOrDefault(r => r.Bookings.Equals(booking.Id));
            var secondCheck = Db.Rooms.FirstOrDefault(r => r.Bookings.Equals(booking.Id));
            var thirdCheck = Db.BookingStatus.FirstOrDefault(r => r.Bookings.Equals(booking.Id));
            var forthCheck = Db.Expenses1.FirstOrDefault(r => r.Booking.Equals(booking.Id));

            return (firstCheck != null && secondCheck != null && thirdCheck != null && forthCheck != null);
        }
    }
}
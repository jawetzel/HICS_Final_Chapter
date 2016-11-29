using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Models.Employees;
using HotelIntegratedComputerSystems.Models.GridView;
using HotelIntegratedComputerSystems.Services.Admin;
using HotelIntegratedComputerSystems.Services.Employee;
using Microsoft.Ajax.Utilities;

namespace HotelIntegratedComputerSystems.Services.GridViewService
{
    public class GridViewServices : BaseServices
    {
        readonly RoomServices _roomsServices = new RoomServices();
        readonly BookingServices _bookingServices = new BookingServices();

        public GridViewRooms GetGridViewRooms(DateTime start, DateTime end)
        {
            var roomsList = _roomsServices.GetRoomList();
            var bookingsList = _bookingServices.GetBookingList().BookingList;

            bookingsList = bookingsList.Where(x => x.StartDate <= end || x.EndDate >= start).ToList();

            if (start > end)
            {
                var startDate = start;
                var endDate = end;

                end = startDate;
                start = endDate;
            }

            Enumerable.Range(0, 1 + end.Subtract(start).Days).Select(offset => start.AddDays(offset)).ToArray();

            List<string> datesList = new List<string>();

            foreach (var room in roomsList)
            {
                for (var dt = start; dt <= end; dt = dt.AddDays(1))
                {
                    var currentDay = bookingsList.FirstOrDefault(x => (x.StartDate <= dt && x.EndDate >= dt) && x.RoomId == room.Id);

                    if (currentDay == null)
                    {
                        room.BookingsList.Add(new BookingViewModel());
                    }
                    else
                    {
                        room.BookingsList.Add(currentDay);
                    }
                }

            }


            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                datesList.Add(dt.ToString("ddd M/dd/yyyy"));

            }

            return new GridViewRooms() { RoomsList = roomsList, DatesList = datesList };

        }
    }
}
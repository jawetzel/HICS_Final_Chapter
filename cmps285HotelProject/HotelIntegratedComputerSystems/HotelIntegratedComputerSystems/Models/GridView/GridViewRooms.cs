using System;
using System.Collections.Generic;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Models.Employees;

namespace HotelIntegratedComputerSystems.Models.GridView
{
    public class GridViewRooms
    {
        public List<RoomViewModel> RoomsList { get; set; }
        public List<string> DatesList { get; set; }
        public BookingViewModel BookingInfo { get; set; }
        public string RoomType { get; set; }
        public string HouseKeepingStatus { get; set; }
    }
}
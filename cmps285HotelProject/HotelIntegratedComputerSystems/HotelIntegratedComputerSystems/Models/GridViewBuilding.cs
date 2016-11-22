using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Models
{
    public class GridViewBuilding
    {
        public List<GridViewFloors> FloorsList { get; set; }
        public string BuildingName { get; set; }
        public int BuildingId { get; set; }

    }

    public class GridViewFloors
    {
        public List<RoomViewModel> RoomsList { get; set; }
        public int FloorNumber { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.HouseKeepingModels
{
    public class HouseKeepingFilterModel
    {
        public bool CleanStatus { get; set; }
        public string CleanStatusFilterWord { get; set; }

        public bool Floor { get; set; }
        public int FloorNumber { get; set; }

        public bool Building { get; set; }
        public int BuildingId { get; set; }
    }
}
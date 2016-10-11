using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Models.HouseKeepingModels
{
    public class HouseKeepingBuildingsViewModel
    {
        public List<HouseKeepingFloorsViewModel> FloorsForBuilding { get; set; }
        public int BuildingId { get; set; }
    }
}
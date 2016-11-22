using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Services.Admin;
using Microsoft.Ajax.Utilities;

namespace HotelIntegratedComputerSystems.Services.GridViewService
{
    public class GridViewServices: BaseServices
    {
        RoomServices roomServices = new RoomServices();

        public List<GridViewBuilding> GetGridViewBuildings()
        {
            var roomsList = roomServices.GetRoomList();
            var buildingsList = roomsList.Select(x => x.BuildingName).Distinct();
            List<GridViewBuilding> returnList = new List<GridViewBuilding>();

            foreach (var building in buildingsList)
            {
                var floorslist = roomsList.Where(x => x.BuildingName == building).Select(x => x.FloorNumber).Distinct();
                var build = new GridViewBuilding();
                build.BuildingName = building;
                foreach (var floor in floorslist)
                {
                    var roomList = roomsList.Where(x => x.BuildingName == building && x.FloorNumber == floor).OrderBy(x => x.RoomNumber);

                    var newfloor = new GridViewFloors();
                    newfloor.FloorNumber = floor;
                    foreach (var room in roomList)
                    {
                        newfloor.RoomsList.Add(room);
                    }

                    build.FloorsList.Add(newfloor);
                }
                returnList.Add(build);
            }

            return returnList;
        }
    }
}
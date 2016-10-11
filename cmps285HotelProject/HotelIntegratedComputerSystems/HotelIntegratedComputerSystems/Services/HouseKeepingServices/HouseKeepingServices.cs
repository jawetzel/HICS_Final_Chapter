using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.HouseKeepingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Services.HouseKeepingServices
{
    public static class HouseKeepingServices
    {
        public static List<HouseKeepingBuildingsViewModel> GetHouseKeepingList(HouseKeepingFilterModel HouseKeepingFilter)
        {
            List<RoomsViewModel> RoomsList = GetRoomsForHousekeeping().ToList()


            int BuildingCounter = 0;

            return Resultlist;
        }

        public static IQueryable<RoomsViewModel> GetRoomsForHousekeeping()
        {

            using (var context = new HicsTestDbEntities1())
            {
                var RoomsQueery = from Room in context.Rooms
                                  join HouseKeeping in context.HouseKeepingStatus on Room.HousekeepingStatusId equals HouseKeeping.Id
                                  join RoomStatus in context.RoomStatus on Room.RoomStatusId equals RoomStatus.Id
                                  where Room.HousekeepingStatusId == HouseKeeping.Id && Room.RoomStatusId == RoomStatus.Id
                                  select new RoomsViewModel
                                  {
                                      Id = Room.Id,
                                      BuildingId = Room.BuildingId,
                                      HousekeepingStatusId = Room.HousekeepingStatusId,
                                      FloorNumber = Room.FloorNumber,
                                      RoomNumber = Room.RoomNumber,
                                      RoomStatusId = Room.RoomStatusId,
                                      CleanStatus = HouseKeeping.CleanStatus,
                                      Description = RoomStatus.Description
                                  };
                return RoomsQueery;
            }
        }
    }
}
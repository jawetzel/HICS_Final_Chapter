using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HotelIntegratedComputerSystems.Models;

namespace HotelIntegratedComputerSystems.Services.MaidService
{
    public class MaidServiceServices
    {
        public HicsTestDbEntities1 Db = new HicsTestDbEntities1();
        public List<HouseKeepingViewModel> GetRoomsForHouseKeeping()
        {

            var roomList = from room in Db.Rooms
                           join houseKeeping in Db.HouseKeepingStatus on room.HousekeepingStatusId equals houseKeeping.Id
                           join building in Db.Buildings on room.BuildingId equals building.Id
                           join roomStat in Db.RoomStatus on room.RoomStatusId equals roomStat.Id
                           join roomType in Db.RoomTypes on room.RoomTypeId equals roomType.Id
                           where room.HousekeepingStatusId == houseKeeping.Id && room.BuildingId == building.Id && room.RoomStatusId == roomStat.Id && room.RoomTypeId == roomType.Id
                           select new HouseKeepingViewModel
                           {
                               Id = room.Id,
                               BuildingId = building.Id,
                               BuildingName = building.Building1,
                               HousekeepingStatusId = houseKeeping.Id,
                               HousekeepingCleanStatus = houseKeeping.CleanStatus,
                               FloorNumber = room.FloorNumber,
                               RoomNumber = room.RoomNumber,
                               RoomStatusId = roomStat.Id,
                               RoomStatusDescription = roomStat.Description,
                               RoomBedding = room.RoomType.Bedding
                           };
            return roomList.ToList();
        }

        public int GetCleanStatusIndex(string status)
        {
            var houseKeepingStatu = Db.HouseKeepingStatus.FirstOrDefault(s => s.CleanStatus.Contains(status));
            if (houseKeepingStatu?.Id != null) return (int) houseKeepingStatu?.Id;
            return 0;
        }

        public void ChangeCleanStatus(int houseKeepingStatusId, int roomId)
        {
            var changeRoom = Db.Rooms.FirstOrDefault(s => s.Id == roomId);
            if (changeRoom != null)
            {
                changeRoom.HousekeepingStatusId = houseKeepingStatusId;

                Db.Entry(changeRoom).State = EntityState.Modified;
            }
            Db.SaveChanges();
        }
    }
}
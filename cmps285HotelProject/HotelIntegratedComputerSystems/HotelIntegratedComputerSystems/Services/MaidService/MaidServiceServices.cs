using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.MaidService;

namespace HotelIntegratedComputerSystems.Services.MaidService
{
    public class MaidServiceServices : BaseServices
    {
        public List<HouseKeepingViewModel> GetRoomsForHouseKeeping()
        {

            var roomList = from room in Db.Rooms
                           select new HouseKeepingViewModel
                           {
                               Id = room.Id,
                               BuildingId = room.Building.Id,
                               BuildingName = room.Building.BuildingName,
                               HousekeepingStatusId = room.HouseKeepingStatu.Id,
                               HousekeepingCleanStatus = room.HouseKeepingStatu.CleanStatus,
                               FloorNumber = room.FloorNumber,
                               RoomNumber = room.RoomNumber,
                               RoomStatusId = room.RoomStatus.Id,
                               RoomStatusDescription = room.RoomStatus.Description,
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
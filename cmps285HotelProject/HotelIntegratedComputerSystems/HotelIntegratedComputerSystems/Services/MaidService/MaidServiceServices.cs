using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HotelIntegratedComputerSystems.Models;

namespace HotelIntegratedComputerSystems.Services.MaidService
{
    public class MaidServiceServices
    {
        private readonly HicsTestDbEntities1 _db = new HicsTestDbEntities1();
        public List<HouseKeepingViewModel> GetRoomsForHouseKeeping()
        {

            var roomList = from room in _db.Rooms
                           select new HouseKeepingViewModel
                           {
                               Id = room.Id,
                               BuildingId = room.Building.Id,
                               BuildingName = room.Building.Building1,
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
            var houseKeepingStatu = _db.HouseKeepingStatus.FirstOrDefault(s => s.CleanStatus.Contains(status));
            if (houseKeepingStatu?.Id != null) return (int) houseKeepingStatu?.Id;
            return 0;
        }

        public void ChangeCleanStatus(int houseKeepingStatusId, int roomId)
        {
            var changeRoom = _db.Rooms.FirstOrDefault(s => s.Id == roomId);
            if (changeRoom != null)
            {
                changeRoom.HousekeepingStatusId = houseKeepingStatusId;

                _db.Entry(changeRoom).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }
    }
}
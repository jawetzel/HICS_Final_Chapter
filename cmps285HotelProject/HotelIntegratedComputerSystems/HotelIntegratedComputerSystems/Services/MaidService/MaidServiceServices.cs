using HotelIntegratedComputerSystems.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Services
{
    public class MaidServiceServices
    {
        public HicsTestDbEntities1 db = new HicsTestDbEntities1();
        public List<HouseKeepingViewModel> GetRoomsForHouseKeeping()
        {

            var RoomList = from room in db.Rooms
                           join HouseKeeping in db.HouseKeepingStatus on room.HousekeepingStatusId equals HouseKeeping.Id
                           join Building in db.Buildings on room.BuildingId equals Building.Id
                           join RoomStat in db.RoomStatus on room.RoomStatusId equals RoomStat.Id
                           join RoomType in db.RoomTypes on room.RoomTypeId equals RoomType.Id
                           where room.HousekeepingStatusId == HouseKeeping.Id && room.BuildingId == Building.Id && room.RoomStatusId == RoomStat.Id && room.RoomTypeId == RoomType.Id
                           select new HouseKeepingViewModel
                           {
                               Id = room.Id,
                               BuildingId = Building.Id,
                               BuildingName = Building.Building1,
                               HousekeepingStatusId = HouseKeeping.Id,
                               HousekeepingCleanStatus = HouseKeeping.CleanStatus,
                               FloorNumber = room.FloorNumber,
                               RoomNumber = room.RoomNumber,
                               RoomStatusId = RoomStat.Id,
                               RoomStatusDescription = RoomStat.Description,
                               RoomBedding = room.RoomType.Bedding
                           };
            return RoomList.ToList();
        }

        public int GetCleanStatusIndex(string Status)
        {
            return db.HouseKeepingStatus.Where(s => s.CleanStatus.Contains(Status)).FirstOrDefault<HouseKeepingStatu>().Id;           
        }

        public void ChangeCleanStatus(int HouseKeepingStatusId, int RoomId)
        {
            Room ChangeRoom = db.Rooms.Where(s => s.Id == RoomId).FirstOrDefault<Room>();
            ChangeRoom.HousekeepingStatusId = HouseKeepingStatusId;

            db.Entry(ChangeRoom).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
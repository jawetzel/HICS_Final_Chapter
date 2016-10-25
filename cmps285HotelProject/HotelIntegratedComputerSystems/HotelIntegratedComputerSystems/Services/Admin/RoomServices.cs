using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Services.MaidService;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class RoomServices : BaseServices
    {
        private readonly MaidServiceServices MaidService = new MaidServiceServices();
        public List<RoomViewModel> GetRoomList()
        {
            var roomList = from room in Db.Rooms
                               select new RoomViewModel
                               {
                                   Id = room.Id,
                                   BuildingId = room.BuildingId,
                                   BuildingName = room.Building.BuildingName,                                  
                                   HouseKeepingStatusId = room.HousekeepingStatusId,
                                   HouseKeepingStatus = room.HouseKeepingStatu.CleanStatus,
                                   RoomTypeId = room.RoomTypeId,
                                   RoomType = room.RoomType.Bedding,
                                   RoomStatusId = room.RoomStatusId,
                                   RoomStatus = room.RoomStatus.Description,
                                   FloorNumber = room.FloorNumber,
                                   RoomNumber = room.RoomNumber,

                               };
            return roomList.ToList();
        }

        public void CreateNewRoom(RoomViewModel room)
        {
            room.HouseKeepingStatusId = MaidService.GetCleanStatusIndex("Clean");
            room.RoomStatusId = GetRoomStatusIndex("Open");
            Db.Rooms.Add(new Room ()
            {
                BuildingId = room.BuildingId,
                RoomTypeId = room.RoomTypeId,
                HousekeepingStatusId = room.HouseKeepingStatusId,
                RoomStatusId = room.RoomStatusId,
                FloorNumber = room.FloorNumber,
                RoomNumber = room.RoomNumber
            });
            Db.SaveChanges();
        }

        public RoomViewModel FindEntryById(int id)
        {
            var room = Db.Rooms.Find(id);
            return (new RoomViewModel
            {
                Id = room.Id,
                BuildingId = room.BuildingId,
                BuildingName = room.Building.BuildingName,
                HouseKeepingStatusId = room.HousekeepingStatusId,
                HouseKeepingStatus = room.HouseKeepingStatu.CleanStatus,
                RoomTypeId = room.RoomTypeId,
                RoomType = room.RoomType.Bedding,
                RoomStatusId = room.RoomStatusId,
                RoomStatus = room.RoomStatus.Description,
                FloorNumber = room.FloorNumber,
                RoomNumber = room.RoomNumber,

            });
        }

        public void PostChangesForEdit(RoomViewModel editBuilding)
        {

            Db.Entry(new Room()
            {
                Id = editBuilding.Id,
                BuildingId = editBuilding.BuildingId,
                RoomTypeId = editBuilding.RoomTypeId,
                HousekeepingStatusId = editBuilding.HouseKeepingStatusId,
                RoomStatusId = editBuilding.RoomStatusId,
                FloorNumber = editBuilding.FloorNumber,
                RoomNumber = editBuilding.RoomNumber
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void DeleteEntry(int id)
        {
            var foundRoom = Db.Rooms.Find(id);
            Db.Rooms.Remove(foundRoom);
            Db.SaveChanges();
        }

        public int GetRoomStatusIndex(string roomStatus)
        {
            var roomStatusReturn = Db.RoomStatus.FirstOrDefault(s => s.Description.Contains(roomStatus));
            if (roomStatusReturn?.Id != null) return (int)roomStatusReturn?.Id;
            return 0;
        }

        public bool CheckForDependencys(int id)
        {
            var room = FindEntryById(id);
            var firstCheck = Db.MaintenanceLogs.FirstOrDefault(R => R.RoomId.Equals(room.Id));
            var seccondChek = Db.Expenses1.FirstOrDefault(R => R.RoomId.Equals(room.Id));
            var thirdCheck = Db.Bookings.FirstOrDefault(R => R.RoomId.Equals(room.Id));

            return (firstCheck != null && seccondChek != null && thirdCheck != null);
        }
    }
}
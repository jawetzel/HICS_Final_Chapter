using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class RoomTypeServices : BaseServices
    {
        public List<RoomTypeViewModel> GetRoomTypesList()
        {
            var roomTypeList = from roomType in Db.RoomTypes
                               select new RoomTypeViewModel
                               {
                                   Id = roomType.Id,
                                   Bedding = roomType.Bedding,
                                   Kitchen = roomType.Kitchen,
                                   Rooms = roomType.Rooms,
                                   BathRooms = roomType.Bathrooms,
                                   SleepsVolume = roomType.SleepsVolume,
                                   NightlyRate = roomType.NightlyRate
                               };
            return roomTypeList.ToList();
        }

        public void CreateNewRoomType(RoomTypeViewModel roomType)
        {

            Db.RoomTypes.Add(new RoomType()
            {
                Id = roomType.Id,
                Bedding = roomType.Bedding,
                Kitchen = roomType.Kitchen,
                Rooms = roomType.Rooms,
                Bathrooms = roomType.BathRooms,
                SleepsVolume = roomType.SleepsVolume,
                NightlyRate = roomType.NightlyRate
            });
            Db.SaveChanges();
        }

        public void PostChangesForEdit(RoomTypeViewModel editRoomType)
        {

            Db.Entry(new RoomType()
            {
                Id = editRoomType.Id,
                Bedding = editRoomType.Bedding,
                Kitchen = editRoomType.Kitchen,
                Rooms = editRoomType.Rooms,
                Bathrooms = editRoomType.BathRooms,
                SleepsVolume = editRoomType.SleepsVolume,
                NightlyRate = editRoomType.NightlyRate
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public RoomTypeViewModel FindEntryById(int id)
        {
            var roomType = Db.RoomTypes.Find(id);
            return (new RoomTypeViewModel
            {
                Id = roomType.Id,
                Bedding = roomType.Bedding,
                Kitchen = roomType.Kitchen,
                Rooms = roomType.Rooms,
                BathRooms = roomType.Bathrooms,
                SleepsVolume = roomType.SleepsVolume,
                NightlyRate = roomType.NightlyRate
            });
        }

        public void DeleteEntry(int id)
        {
            var foundRoomType = Db.RoomTypes.Find(id);
            Db.RoomTypes.Remove(foundRoomType);
            Db.SaveChanges();
        }

        public bool CheckForDependencys(int id)
        {
            var roomType = FindEntryById(id);

            return (roomType != null);
        }
    }
}
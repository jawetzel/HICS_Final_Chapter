using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;
using HotelIntegratedComputerSystems.Models.Admin.MaintenanceLog;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class MaintenanceLogServices : BaseServices
    {
        public PackageMaintenanceLogViewModel GetMaintenanceLogList()
        {
            var maintLogList = from maintLog in Db.MaintenanceLogs
                           select new MaintenanceLogViewModel()
                           {
                               Id = maintLog.Id,
                               RoomId = maintLog.RoomId,
                               BuildingId = maintLog.Room.BuildingId,
                               BuildingName = maintLog.Room.Building.BuildingName,
                               Floor = maintLog.Room.FloorNumber,
                               RoomNumber = maintLog.Room.RoomNumber,
                               Date = maintLog.Date,
                               Description = maintLog.Description,
                               MaintenanceTypeId = maintLog.MaintenanceTypesId,
                               MaintenanceType = maintLog.MaintenanceType.Type,
                           };
            return new PackageMaintenanceLogViewModel() {MaintenanceLogsList = maintLogList.ToList()};
        }

        public PackageMaintenanceLogViewModel InfoForMaintenaneLogCreateEdit()
        {
            var roomsList = from rooms in Db.Rooms
                            select new RoomViewModel()
                            {
                                Id = rooms.Id,
                                BuildingId = rooms.BuildingId,
                                BuildingName = rooms.Building.BuildingName,
                                FloorNumber = rooms.FloorNumber,
                                RoomNumber = rooms.RoomNumber,
                                RoomStatusId = rooms.RoomStatusId,
                                RoomStatus = rooms.RoomStatus.Description

                            };

            var maintTypeList = from maintType in Db.MaintenanceTypes
                            select new MaintenanceTypeViewModel()
                            {
                                Id = maintType.Id,
                                Type = maintType.Type
                            };

            return new PackageMaintenanceLogViewModel() {RoomsList = roomsList.ToList(), MaintenanceTypeList = maintTypeList.ToList()};
        }

        public void CreateNewMaintenanceLog(PackageMaintenanceLogViewModel model)
        {
            Db.MaintenanceLogs.Add(new MaintenanceLogs()
            {
                RoomId = model.MaintenanceLog.RoomId,
                Date = model.MaintenanceLog.Date,
                Description = model.MaintenanceLog.Description,
                MaintenanceTypesId = model.MaintenanceLog.MaintenanceTypeId        
            });
            Db.SaveChanges();
        }

        public int GetRoomId(string building, int floor, string roomNumber)
        {
            return Db.Rooms.FirstOrDefault(x => x.Building.BuildingName == building && x.FloorNumber == floor && x.RoomNumber == roomNumber).Id;
        }

        public int GetMaintenanceTypeByName(string type)
        {
            return Db.MaintenanceTypes.FirstOrDefault(x => x.Type == type).Id;
        }
        public void PostChangesForEdit(PackageMaintenanceLogViewModel model)
        {
            Db.Entry(new MaintenanceLogs()
            {
                Id = model.MaintenanceLog.Id,
                Date = model.MaintenanceLog.Date,
                MaintenanceTypesId = model.MaintenanceLog.MaintenanceTypeId,
                RoomId = model.MaintenanceLog.RoomId,
                Description = model.MaintenanceLog.Description
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void DeleteEntry(int id)
        {
            var foundMaintLog = Db.MaintenanceLogs.Find(id);
            Db.MaintenanceLogs.Remove(foundMaintLog);
            Db.SaveChanges();
        }

        public PackageMaintenanceLogViewModel FindEntryById(int id)
        {
            var maintLog = Db.MaintenanceLogs.Find(id);
            return (new PackageMaintenanceLogViewModel
            {
                MaintenanceLog = new MaintenanceLogViewModel()
                {
                    Id = maintLog.Id,
                    BuildingId = maintLog.Room.BuildingId,
                    BuildingName = maintLog.Room.Building.BuildingName,
                    Date = maintLog.Date,
                    Description = maintLog.Description,
                    Floor = maintLog.Room.FloorNumber,
                    MaintenanceTypeId = maintLog.MaintenanceTypesId,
                    MaintenanceType = maintLog.MaintenanceType.Type,
                    RoomId = maintLog.RoomId,
                    RoomNumber = maintLog.Room.RoomNumber
                }
            });
        }
    }
}
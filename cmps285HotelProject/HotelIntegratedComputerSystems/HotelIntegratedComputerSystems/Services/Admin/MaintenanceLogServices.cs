using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin.MaintenanceLog;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class MaintenanceLogServices : BaseServices
    {
        public PackageMaintenanceLogViewModel MaintenanceLogList()
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
    }
}
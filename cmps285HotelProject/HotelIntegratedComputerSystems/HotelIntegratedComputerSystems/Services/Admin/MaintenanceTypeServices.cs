using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class MaintenanceTypeServices : BaseServices
    {
        public List<MaintenanceTypeViewModel> GetMaintenanceTypeList()
        {
            var maintenanceTypeList = from maintenanceType in Db.MaintenanceTypes
                               select new MaintenanceTypeViewModel
                               {
                                   Id = maintenanceType.Id,
                                   Type = maintenanceType.Type
                               };
            return maintenanceTypeList.ToList();
        }

        public void CreateMaintenanceType(MaintenanceTypeViewModel MaintenanceType)
        {

            Db.MaintenanceTypes.Add(new MaintenanceTypes
            {
                Id = MaintenanceType.Id,
                Type = MaintenanceType.Type
            });
            Db.SaveChanges();
        }

        public void PostChangesForEdit(MaintenanceTypeViewModel editMaintenanceType)
        {

            Db.Entry(new MaintenanceTypes()
            {
                Id = editMaintenanceType.Id,
                Type = editMaintenanceType.Type
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public MaintenanceTypeViewModel FindEntryById(int id)
        {
            var maintenanceType = Db.MaintenanceTypes.Find(id);
            return (new MaintenanceTypeViewModel
            {
                Id = maintenanceType.Id,
                Type = maintenanceType.Type
            });
        }

        public void DeleteEntry(int id)
        {
            var foundMaintenceType = Db.MaintenanceTypes.Find(id);
            Db.MaintenanceTypes.Remove(foundMaintenceType);
            Db.SaveChanges();
        }

        public bool CheckForDependencys(int id)
        {
            var maintenanceType = FindEntryById(id);
            var firstMatch = Db.MaintenanceLogs.FirstOrDefault(R => R.MaintenanceTypesId.Equals(maintenanceType.Id));
            return firstMatch != null;
        }
    }
}
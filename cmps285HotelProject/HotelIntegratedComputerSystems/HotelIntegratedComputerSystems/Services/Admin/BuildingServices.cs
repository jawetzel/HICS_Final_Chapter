using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Models.Admin;

namespace HotelIntegratedComputerSystems.Services.Admin
{
    public class BuildingServices : BaseServices
    {
        public List<BuildingViewModel> GetBuildingsList()
        {
            var buildingList = from build in Db.Buildings
                               select new BuildingViewModel
                               {
                                   Id = build.Id,
                                   Phone = build.Phone,
                                   Address = build.Address,
                                   BuildingName = build.Building1
                               };
            return buildingList.ToList();
        }

        public void CreateNewBuilding(BuildingViewModel Building)
        {

            Db.Buildings.Add(new Building
            {
                Id = Building.Id,
                Phone = Building.Phone,
                Address = Building.Address,
                Building1 = Building.BuildingName
            });
            Db.SaveChanges();
        }

        public void PostChangesForEdit(BuildingViewModel editBuilding)
        {

            Db.Entry(new Building()
            {
                Id = editBuilding.Id,
                Phone = editBuilding.Phone,
                Address = editBuilding.Address,
                Building1 = editBuilding.BuildingName
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public BuildingViewModel FindEntryById(int id)
        {
            var foundBuilding = Db.Buildings.Find(id);
            return (new BuildingViewModel
            {
                Id = foundBuilding.Id,
                Phone = foundBuilding.Phone,
                Address = foundBuilding.Address,
                BuildingName = foundBuilding.Building1
            });
        }

        public void DeleteEntry(int id)
        {
            var foundBuilding = Db.Buildings.Find(id);
            Db.Buildings.Remove(foundBuilding);
            Db.SaveChanges();
        }

        public bool CheckForDependencys(int id)
        {
            var building =  FindEntryById(id);
            var firstMatch = Db.Rooms.FirstOrDefault(R => R.BuildingId.Equals(building.Id));
            return firstMatch != null;
        }
    }
}
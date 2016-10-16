﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Services;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Models.Admin
{
    public class EmployeeTypeServices : BaseServices
    {
        public List<EmployeeTypeViewModel> GetEmployeeTypeList()
        {
            var employeeTypesList = from employeeType in Db.EmployeeTypes
                           select new EmployeeTypeViewModel
                           {
                               Id = employeeType.Id,
                               SecurityRankId = employeeType.SecurityRankId,
                               SecurityRankDescription = employeeType.SecurityRank.AccessLevelDescription,
                               Title = employeeType.Title,
                               PayRate = employeeType.PayRate
                           };
            return employeeTypesList.ToList();
        }

        public void CreateNewEmployeeType(EmployeeTypeViewModel employeeType)
        {

            Db.EmployeeTypes.Add(new EmployeeType()
            {
                Id = employeeType.Id,
                SecurityRankId = employeeType.SecurityRankId,
                Title = employeeType.Title,
                PayRate = employeeType.PayRate
            });
            Db.SaveChanges();
        }

        public EmployeeTypeViewModel FindEntryById(int id)
        {
            var employeeType = Db.EmployeeTypes.Find(id);
            return (new EmployeeTypeViewModel
            {
                Id = employeeType.Id,
                SecurityRankId = employeeType.SecurityRankId,
                SecurityRankDescription = employeeType.SecurityRank.AccessLevelDescription,
                Title = employeeType.Title,
                PayRate = employeeType.PayRate
            });
        }

        public void PostChangesForEdit(EmployeeTypeViewModel employeeType)
        {

            Db.Entry(new EmployeeType
            {
                Id = employeeType.Id,
                SecurityRankId = employeeType.SecurityRankId,
                Title = employeeType.Title,
                PayRate = employeeType.PayRate
                
            })
            .State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void DeleteEntry(int id)
        {
            var foundEmployeeType = Db.EmployeeTypes.Find(id);
            Db.EmployeeTypes.Remove(foundEmployeeType);
            Db.SaveChanges();
        }
    }
}
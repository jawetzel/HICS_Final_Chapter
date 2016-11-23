using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Controllers.Default
{
    public class GoogleAccount : BaseController
    {
        private readonly EmployeeServies _services = new EmployeeServies();

        public static int Id;
        public static int TypeId;
        public static string TypeTitle;
        public static string Email;
        public static string Address;
        public static double Phone;
        public static string Name;
        public static int Authority;
        public static bool IsLogged;

        
        public GoogleAccount()
        {
            
        }

        public GoogleAccount(string emailAddress, bool isLoggedOn)
        {
            Email = emailAddress;
            IsLogged = isLoggedOn;

            var employee = Db.Employees.FirstOrDefault(x => x.Email == Email);  //  get employee object from Db
            var employeeSecurity = Db.Employees.First(x => x.Email == Email).EmployeeType.SecurityRank; //  get security rank object from employee

            //  now grab all of the employee information and set it in our public variables
            TypeTitle = employeeSecurity.AccessLevelDescription;
            TypeId = employeeSecurity.SiteAccessLevel;
            Address = employee.Address;
            Phone = employee.Phone;
            Name = employee.Name;
            Authority = 0; //  NOTE: Change all these once database is up-to-date
        }


        //  clean all variables
        public void DisposeAccount()
        {
            Id = 0;
            TypeId = 0;
            TypeTitle = null;
            Email = null;
            Address = null;
            Phone = 0;
            Name = null;
            Authority = 0;
            IsLogged = false;
        }
    }
}
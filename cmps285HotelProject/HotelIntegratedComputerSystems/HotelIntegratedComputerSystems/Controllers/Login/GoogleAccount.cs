using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelIntegratedComputerSystems.Models;
using HotelIntegratedComputerSystems.Services.Admin;

namespace HotelIntegratedComputerSystems.Controllers.Login
{
    public class GoogleAccount : BaseController
    {
        private readonly EmployeeServies _services = new EmployeeServies();

        public static int Id;
        public static int EmployeeTypeId;
        public static string EmployeeTypeTitle;
        public static string Email;
        public static string Address;
        public static double Phone;
        public static string Name;
        public static int Authority;

        
        public GoogleAccount()
        {
            
        }

        public GoogleAccount(string emailAddress)
        {
            Email = emailAddress;

            //  error here. Fix..
            //var employee = Db.Employees.Find(emailAddress);
            //  emailAddress wont work in the find function because it is not a primary key? 
                //  need a new table for our database
            var employee = Db.Employees.Find(emailAddress);

            //  now grab all of the employee information and set it in our public variables
            EmployeeTypeId = employee.EmployeeTypeId;
            EmployeeTypeTitle = employee.EmployeeType.Title;
            Email = employee.Email;
            Address = employee.Address;
            Phone = employee.Phone;
            Name = employee.Name;
            Authority = 0000000000000000000000; //  NOTE: Change all these once database is up-to-date
            System.Diagnostics.Debug.WriteLine("** The user email = " + Email);

        }


        //  clean all variables
        public void DisposeAccount()
        {
            Id = 0;
            EmployeeTypeId = 0;
            EmployeeTypeTitle = null;
            Email = null;
            Address = null;
            Phone = 0;
            Name = null;
            Authority = 0;
        }
    }
}
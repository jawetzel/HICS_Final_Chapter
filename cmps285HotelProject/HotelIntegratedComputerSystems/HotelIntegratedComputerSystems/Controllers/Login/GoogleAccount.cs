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
        public static int TypeId;
        public static string TypeTitle;
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
            var employee = Db.Employees.FirstOrDefault(x => x.Email == Email);

            //  now grab all of the employee information and set it in our public variables
            TypeId = employee.EmployeeType.Id;
            TypeTitle = employee.EmployeeType.Title;
            Address = employee.Address;
            Phone = employee.Phone;
            Name = employee.Name;
            Authority = 0; //  NOTE: Change all these once database is up-to-date
            System.Diagnostics.Debug.WriteLine("** The user Address = " + Address);
            System.Diagnostics.Debug.WriteLine("** The user Phone = " + Phone);
            System.Diagnostics.Debug.WriteLine("** The user Name = " + Name);
            System.Diagnostics.Debug.WriteLine("** The user Authority = " + Authority);
            System.Diagnostics.Debug.WriteLine("** The user ID = " + TypeTitle);
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
        }
    }
}
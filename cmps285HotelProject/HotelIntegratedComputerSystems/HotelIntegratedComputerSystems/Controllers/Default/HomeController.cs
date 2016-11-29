using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using HotelIntegratedComputerSystems.Controllers.Default;
using HotelIntegratedComputerSystems.Models;
using Microsoft.Ajax.Utilities;

namespace HotelIntegratedComputerSystems.Controllers.Default
{
    public class HomeController : BaseController
    {
        [HttpPost]
        public ActionResult LogIn(string googleEmail)
        {
            LogIn_System(googleEmail);  // send googleEmail to LogIn_System method

            if(Session["IsLoggedOn"] != null && Session["AccessLevel"] != null)
            {
                return Json(new { isUser = bool.Parse(Session["IsLoggedOn"].ToString()), accessLevel = Session["AccessLevel"].ToString() }, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpPost]
        public Action LogOut()
        {
            //  remove/set all info of user back to default
            Session["Id"] = 0;
            Session["Email"] = null;
            Session["IsLoggedOn"] = false;
            Session["AccessLevel"] = null;
            Session["Address"] = null;
            Session["Phone"] = null;
            Session["Name"] = null;

            return null;
        }

        public void LogIn_System(string emailAddress)
        {
            if (IsLoginNameExist(emailAddress))
            {
                Session["Email"] = emailAddress;
                Session["IsLoggedOn"] = true;

                var employee = Db.Employees.FirstOrDefault(x => x.Email == emailAddress);  //  get employee object from Db
                var employeeSecurity = Db.Employees.First(x => x.Email == emailAddress).EmployeeTypeId; //  get security rank object from employee

                //  now grab all of the employee information and set it in our public variables
                Session["AccessLevel"] = employeeSecurity;
                Session["Id"] = employee.Id;
                Session["Address"] = employee.Address;
                Session["Phone"] = employee.Phone;
                Session["Name"] = employee.Name;
            }
        }


        //  check to see if the email address is in our database
        public bool IsLoginNameExist(string emailAddress)
        {
            return Db.Employees.Any(o => o.Email.Equals(emailAddress));
        }


        // GET: GoogleLoginViewModels
        public ActionResult Index()
        {
            return View();
        }

        //  dispose of database
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

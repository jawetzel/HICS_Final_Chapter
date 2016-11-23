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
        public string LoggedEmail = GoogleAccount.Email;
        public string LoggedUser = GoogleAccount.Name;

        [HttpPost]
        public ActionResult LogIn(string googleEmail)
        {
            LogIn_System(googleEmail);  // send googleEmail to LogIn_System method
            return Json(new { isUser = GoogleAccount.IsLogged, typeId = GoogleAccount.TypeId }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public Action LogOut()
        {
            //  remove/set all info of user back to default
            GoogleAccount ga = new GoogleAccount();
            ga.DisposeAccount();

            return null;
        }

        public void LogIn_System(string emailAddress)
        {
            if (IsLoginNameExist(emailAddress))
            {
                System.Diagnostics.Debug.WriteLine("The user is in our database.");
                GoogleAccount ga = new GoogleAccount(emailAddress, true);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Controllers.Default;
using HotelIntegratedComputerSystems.Controllers.Login;
using HotelIntegratedComputerSystems.Models;
using Microsoft.Ajax.Utilities;


namespace HotelIntegratedComputerSystems.Controllers.Login
{
    public class GoogleLoginViewModelsController : BaseController
    {

        //  need to add all of the other variables but these should go on different controllers... ?probably just base controller?
        private string loggedUser = GoogleAccount.Email;    //  this will grab the email of the user(if there is one signed in)
        private int userRankId = GoogleAccount.Authority;   //  this will grab the rank of the user(if there is one signed in)



        [HttpPost]
        public Action LogIn(string googleEmail)
        {
            LogIn_System(googleEmail);  // send googleEmail to LogIn_System method
            return null;
        }

        public void LogIn_System (string emailAddress)
        {
            if (IsLoginNameExist(emailAddress))
            {
                System.Diagnostics.Debug.WriteLine("The user is in our database.");
                GoogleAccount ga = new GoogleAccount(emailAddress);
                
                //  need to make an object of Logged User later also ask josh about admin users...?

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("User is NOT in our database");
                //  need to add else later... send back to user that they are not a member of HICS
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelIntegratedComputerSystems.Controllers
{
    public class NotAuthorizedController : Controller
    {
        // GET: NotAuthorized
        public ActionResult Index()
        {
            return View();
        }
    }
}
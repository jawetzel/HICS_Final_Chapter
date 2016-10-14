using HotelIntegratedComputerSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelIntegratedComputerSystems.Controllers
{
    public class BaseController : Controller
    {

        public HicsTestDbEntities1 Db = new HicsTestDbEntities1();


        //base page security goes here
    }
}
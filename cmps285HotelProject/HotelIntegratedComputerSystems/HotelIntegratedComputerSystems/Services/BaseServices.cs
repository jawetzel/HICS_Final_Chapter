using HotelIntegratedComputerSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelIntegratedComputerSystems.Services
{
    public class BaseServices
    {
        protected readonly HicsTestDbEntities1 Db = new HicsTestDbEntities1();
    }
}
using System.Web.Mvc;

namespace HotelIntegratedComputerSystems.Controllers
{
    public class NullController : Controller
    {
        public ActionResult Index()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Net;
using System.Web.Mvc;
using HotelIntegratedComputerSystems.Services.MaidService;
using HotelIntegratedComputerSystems.Models.MaidService;
using HotelIntegratedComputerSystems.Controllers.Default;

namespace HotelIntegratedComputerSystems.Controllers.MaidService
{
    public class HouseKeepingController : BaseController
    {
        private readonly MaidServiceServices _service = new MaidServiceServices();

        public ActionResult Index()
        {
            if (GoogleAccount.TypeId < 1) { return Redirect("~/NotAuthorized/Index"); }
            return View(_service.GetRoomsForHouseKeeping());
        }
        
        public ActionResult Clean(int? id)
        {
            if (GoogleAccount.TypeId < 1) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _service.ChangeCleanStatus(_service.GetCleanStatusIndex("Clean"), id.Value);
            return RedirectToAction("Index");
        }

        public ActionResult Dirty(int? id)
        {
            if (GoogleAccount.TypeId < 1) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _service.ChangeCleanStatus(_service.GetCleanStatusIndex("Dirty"), id.Value);
            return RedirectToAction("Index");
        }

        public ActionResult Dnd(int? id)
        {
            if (GoogleAccount.TypeId < 1) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _service.ChangeCleanStatus(_service.GetCleanStatusIndex("Do Not Disturb"), id.Value);
            return RedirectToAction("Index");
        }

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

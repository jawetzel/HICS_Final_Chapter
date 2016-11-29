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
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 2  || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            return View(_service.GetRoomsForHouseKeeping());
        }
        
        public ActionResult Clean(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 2  || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _service.ChangeCleanStatus(_service.GetCleanStatusIndex("Clean"), id.Value);
            return RedirectToAction("Index");
        }

        public ActionResult Dirty(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 2  || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _service.ChangeCleanStatus(_service.GetCleanStatusIndex("Dirty"), id.Value);
            return RedirectToAction("Index");
        }

        public ActionResult Dnd(int? id)
        {
            if (Session["AccessLevel"] == null || int.Parse(Session["AccessLevel"].ToString()) == 2  || int.Parse(Session["AccessLevel"].ToString()) == 3) { return Redirect("~/NotAuthorized/Index"); }
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

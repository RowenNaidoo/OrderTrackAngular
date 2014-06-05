using System.Web.Mvc;

namespace WebAPIApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Json("");
            return View();
        }
    }
}

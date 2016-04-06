using System.Web.Mvc;

namespace ConnectnowWeb.Controllers
{
    [SubdomainRoute("{action=Index}", "randw")]
    public class RNWController : Controller
    {
        // GET: RNW
        public ActionResult Index()
        {
            return View();
        }
    }
}
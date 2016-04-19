using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectnowWeb.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string subdomain)
        {
            ViewBag.Subdomain = subdomain;
            return View();
        }
    }
}
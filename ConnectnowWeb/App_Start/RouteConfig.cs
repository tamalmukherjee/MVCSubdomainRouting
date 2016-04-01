using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConnectnowWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.Add("Default", new SubdomainRoute("{controller}/{action}/{id}")
            {
                Defaults = new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
                Constraints = new RouteValueDictionary(),
                DataTokens = new RouteValueDictionary()
            });
        }

        //static void MapSubdomainRoute(this RouteCollection routes, string name, string url, object defaults = null, object constraints = null)
        //{
        //    routes.Add(name, new SubdomainRoute(url)
        //    {
        //        Defaults = new RouteValueDictionary(defaults),
        //        Constraints = new RouteValueDictionary(constraints),
        //        DataTokens = new RouteValueDictionary()
        //    });
        //}
    }
}

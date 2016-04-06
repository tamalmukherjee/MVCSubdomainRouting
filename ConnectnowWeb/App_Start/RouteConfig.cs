namespace ConnectnowWeb
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.Add(
                "Default",
                new SubdomainRoute("{controller}/{action}/{id}")
            {
                Defaults = new RouteValueDictionary(
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
                Constraints = new RouteValueDictionary(),
                DataTokens = new RouteValueDictionary()
            });
        }
    }
}
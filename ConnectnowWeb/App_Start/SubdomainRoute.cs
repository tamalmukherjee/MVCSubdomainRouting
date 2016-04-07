namespace ConnectnowWeb
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class SubdomainRoute : Route
    {
        public SubdomainRoute(string url)
            : base(url, new MvcRouteHandler())
        {
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);

            string subdomain = httpContext.Request.Url.Host.Split('.').First().ToLower();
            string[] whitelist = { "randw", "harcourts", "www" };
            if (!whitelist.Contains(subdomain))
            {
                subdomain = string.Empty;
            }

            routeData.Values.Add("subdomain", subdomain);
            return routeData;
        }
    }
}
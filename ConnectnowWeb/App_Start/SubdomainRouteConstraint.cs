namespace ConnectnowWeb
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;

    public class SubdomainRouteConstraint : IRouteConstraint
    {
        //http://weblogs.asp.net/jongalloway/looking-at-asp-net-mvc-5-1-and-web-api-2-1-part-2-attribute-routing-with-custom-constraints
        public SubdomainRouteConstraint(string subdomain)
        {
            Subdomain = subdomain;
        }

        public string Subdomain { get; private set; }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string subdomain = httpContext.Request.Url.Host.Split('.').First().ToLower();
            if (isValid(subdomain))
            {
                return string.Equals(Subdomain, subdomain, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        private bool isValid(string subdomain)
        {
            string[] validOptions = "www|harcourts|randw".Split('|');
            return validOptions.Contains(subdomain.ToLower());
        }
    }
}
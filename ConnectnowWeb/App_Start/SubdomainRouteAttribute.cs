namespace ConnectnowWeb
{
    using System.Web.Mvc.Routing;
    using System.Web.Routing;

    public class SubdomainRouteAttribute : RouteFactoryAttribute
    {
        public SubdomainRouteAttribute(string template, string subdomain)
            : base(template)
        {
            Subdomain = subdomain;
        }

        public string Subdomain
        {
            get;
            private set;
        }

        public override RouteValueDictionary Constraints
        {
            get
            {
                var constraints = new RouteValueDictionary();
                constraints.Add("subdomain", new SubdomainRouteConstraint(Subdomain));
                return constraints;
            }
        }

        public override RouteValueDictionary Defaults
        {
            get
            {
                var defaults = new RouteValueDictionary();
                defaults.Add("subdomain", "www");
                return defaults;
            }
        }
    }
}
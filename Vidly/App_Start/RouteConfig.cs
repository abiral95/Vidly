using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //enabling attribute routing
            routes.MapMvcAttributeRoutes();

            //    routes.MapRoute(
            //       "MoviesByReleaseDate",
            //       "movies/Released/{year}/{month}",
            //       new {controller="Movies", action = "ByReleaseDate"},
            //     //now putting constraints
            //    new {year = @"\d{4}", month = @"\d{2}"}
            //    //regular expressions are used..if you dont use '@' put double slash \\
            //   //if u want to put year constraints to 2015 and 2016 only then @"2015|2016"
            //  );





            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

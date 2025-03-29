using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hrms
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employees", action = "EmployeeForm", id = UrlParameter.Optional }
            );
             routes.MapRoute(
             name: "DeleteAttendance",
             url: "Attendance/Delete/{id}",
             defaults: new { controller = "Attendance", action = "Delete" }
            );

            routes.MapRoute(
            name: "Edit Attendance",
            url: "Attendance/Edit/{id}",
            defaults: new { controller = "Attendance", action = "Edit" }
           );

        }
    }
}

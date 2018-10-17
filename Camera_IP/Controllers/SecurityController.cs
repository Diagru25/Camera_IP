using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camera_IP.Common;

namespace Camera_IP.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        // GET: Admin/Security
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session[CommonHelp.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
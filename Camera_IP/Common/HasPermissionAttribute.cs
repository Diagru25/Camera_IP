using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Camera_IP.Common
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public int RoleID { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session =HttpContext.Current.Session[CommonHelp.USER_SESSION];
            if (session != null )
            {               
               if (RoleID == Convert.ToInt16(session))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            var values = new RouteValueDictionary(new
            {
                action = "Error401",
                controller = "Login"
            });
            filterContext.Result = new RedirectToRouteResult(values);
        }











    }
}
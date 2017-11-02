using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace RTV.Models
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {

                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Home/LogIn" }));

                //filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Home/LogIn" }));
            }
        }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    string cookieName = FormsAuthentication.FormsCookieName;

        //    if (!filterContext.HttpContext.User.Identity.IsAuthenticated ||
        //        filterContext.HttpContext.Request.Cookies == null ||
        //        filterContext.HttpContext.Request.Cookies[cookieName] == null
        //    )
        //    {
        //        HandleUnauthorizedRequest(filterContext);
        //        return;
        //    }

        //    var authCookie = filterContext.HttpContext.Request.Cookies[cookieName];
        //    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        //    string[] roles = authTicket.UserData.Split(',');

        //    var userIdentity = new GenericIdentity(authTicket.Name);
        //    var userPrincipal = new GenericPrincipal(userIdentity, roles);

        //    filterContext.HttpContext.User = userPrincipal;
        //    base.OnAuthorization(filterContext);
        //}
    }
}
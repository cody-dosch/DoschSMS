using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagementSystem.Extensions
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Get the current user from Session
            var user = HttpContext.Current.Session["User"] as UserModel;

            // If a user is logged in and has the correct role, pass authorization
            if (user != null)
            {
                // If Roles need to be checked
                if (!string.IsNullOrEmpty(Roles))
                {
                    if (user.Role.Equals(Roles, StringComparison.InvariantCultureIgnoreCase))
                        return true;
                    else
                        HttpContext.Current.Session["InvalidRole"] = 1;
                }
                else
                {
                    // Authorize if roles don't need to be checked
                    return true;
                }            
            }

            // Else, fail authorization
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var invalidRole = HttpContext.Current.Session["InvalidRole"] as int? ?? 0;

            if (invalidRole == 1)
            {
                // Clear InvalidRole value from Session
                HttpContext.Current.Session.Remove("InvalidRole");

                // Redirect to InvalidRole Page if not authorized for page
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Errors",
                    action = "InvalidRole"
                }));
            }
            else
            {
                // Redirect to Login Page if not logged in
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Login"
                }));
            }
            
        }
    }
}
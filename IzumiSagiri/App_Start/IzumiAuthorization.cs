using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzumiSagiri.App_Start
{
    public class IzumiAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                return false;
            }
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            return true;
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            IzumiPrincipal principal = new IzumiPrincipal(HttpContext.Current.User.Identity.Name);
            filterContext.HttpContext.User = principal;

            if (!AuthorizeCore(filterContext.HttpContext))
            {
                string returnUrl = "/Sign/SignIn?returnUrl=";
                var paras = filterContext.HttpContext.Request.Params;
                var paraNames = filterContext.ActionDescriptor.GetParameters();
                returnUrl += "/" + controllerName + "/" + actionName;
                var param = filterContext.HttpContext.Request.QueryString;
                if (param.Count > 0)
                {
                    returnUrl += "?";
                }
                foreach (string p in param.Keys)
                {
                    returnUrl += p + "=" + param[p] + "&";
                }
                filterContext.Result = new RedirectResult(returnUrl);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.Filter
{
    public class CustomAuthorizationFilterAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IPrincipal incomingPrincipal = actionContext.RequestContext.Principal;
            Console.WriteLine(string.Format("Principal is authenticated at the start of IsAuthorized in CustomAuthorizationFilterAttribute: {0}", incomingPrincipal.Identity.IsAuthenticated));
            return false;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            Console.WriteLine("Running HandleUnauthorizedRequest in CustomAuthorizationFilterAttribute as principal is not authorized.");
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}
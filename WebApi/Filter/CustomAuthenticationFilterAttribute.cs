using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace WebApi.Filter
{
    public class CustomAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get { return false; }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                IPrincipal incomingPrincipal = context.ActionContext.RequestContext.Principal;
                Console.WriteLine(String.Format("Incoming principal in custom auth filter AuthenticateAsync method is authenticated: {0}", incomingPrincipal.Identity.IsAuthenticated));
                IPrincipal genericPrincipal = new GenericPrincipal(new GenericIdentity("Andras", "CustomIdentification"), new string[] { "Admin", "PowerUser" });
                context.Principal = genericPrincipal;
            });
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
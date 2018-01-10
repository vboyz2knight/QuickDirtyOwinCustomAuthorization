using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOwin.Authentication
{
    public class PinBasedAuthMiddleware : AuthenticationMiddleware<PinBasedAuthenticationOptions>
    {
        public PinBasedAuthMiddleware(OwinMiddleware nextMiddleware, PinBasedAuthenticationOptions authOptions)
            : base(nextMiddleware, authOptions)
        { }

        protected override AuthenticationHandler<PinBasedAuthenticationOptions> CreateHandler()
        {
            return new PinAuthenticationHandler();
        }
    }
}
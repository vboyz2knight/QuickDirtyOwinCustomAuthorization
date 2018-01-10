using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOwin.Authentication
{
    public static class PinAuthenticationExtension
    {
        public static void UsePinBasedAuthentication(this IAppBuilder appBuilder)
        {
            appBuilder.Use<PinBasedAuthMiddleware>(new PinBasedAuthenticationOptions());
        }
    }
}
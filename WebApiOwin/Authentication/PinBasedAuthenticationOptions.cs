using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOwin.Authentication
{
    public class PinBasedAuthenticationOptions : AuthenticationOptions
    {
        public PinBasedAuthenticationOptions() : base("x-company-auth")
        {
        }
    }
}
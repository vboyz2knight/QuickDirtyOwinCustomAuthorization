using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.Owin;
using System.Security.Claims;

namespace WebApiOwin.Authentication
{
    public class PinAuthenticationHandler : AuthenticationHandler<PinBasedAuthenticationOptions>
    {
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            bool authorized = await Task<bool>.Run(() => IsAuthorised(Request.Headers));
            if (authorized)
            {
                AuthenticationProperties authProperties = new AuthenticationProperties();
                authProperties.IssuedUtc = DateTime.UtcNow;
                authProperties.ExpiresUtc = DateTime.UtcNow.AddDays(1);
                authProperties.AllowRefresh = true;
                authProperties.IsPersistent = true;
                IList<Claim> claimCollection = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Andras")
                    , new Claim(ClaimTypes.Country, "Sweden")
                    , new Claim(ClaimTypes.Gender, "M")
                    , new Claim(ClaimTypes.Surname, "Nemes")
                    , new Claim(ClaimTypes.Email, "hello@me.com")
                    , new Claim(ClaimTypes.Role, "IT")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection, "Custom");
                AuthenticationTicket ticket = new AuthenticationTicket(claimsIdentity, authProperties);
                return ticket;
            }

            return null;
        }

        private bool IsAuthorised(IHeaderDictionary requestHeaders)
        {
            string[] acceptLanguageValues;
            bool acceptLanguageHeaderPresent = requestHeaders.TryGetValue("x-company-auth", out acceptLanguageValues);
            if (acceptLanguageHeaderPresent)
            {
                string[] elementsInHeader = acceptLanguageValues.ToList()[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (elementsInHeader.Length == 2)
                {
                    int pin;
                    if (int.TryParse(elementsInHeader[1], out pin))
                    {
                        if (pin == 1234)
                        {
                            return true;
                        }
                    }
                }
            }
            else if(this.Context.Request.Path.ToString() == "/customers/Anonymous")   //ugly hack
            {
                //HttpContextBase httpContext = this.Context.Get<HttpContextBase>(typeof(HttpContextBase).FullName);
                return true;
            }
            return false;
        }
    }    
}
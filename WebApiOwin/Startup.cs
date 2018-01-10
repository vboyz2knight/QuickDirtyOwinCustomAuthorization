using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiOwin.Authentication;

namespace WebApiOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {            
            Debug.WriteLine("OWIN is working.");
            appBuilder.UsePinBasedAuthentication();
        }
    }
}
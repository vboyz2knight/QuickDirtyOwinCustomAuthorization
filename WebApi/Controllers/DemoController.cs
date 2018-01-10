using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class DemoController : ApiController
    {
        public IHttpActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult AnonymousCall()
        {
            return Ok(new {ID = "Anonymous", Value = "You made it with no cred." });
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult NonAnonymousCall()
        {
            return Ok(new { ID = "Authorize", Value = "You made it with cred." });
        }
    }
}

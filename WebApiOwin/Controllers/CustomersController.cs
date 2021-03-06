﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiOwin.Models;

namespace WebApiOwin.Controllers
{
    public class CustomersController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            IList<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Nice customer", Address = "USA", Telephone = "123345456" });
            customers.Add(new Customer() { Name = "Good customer", Address = "UK", Telephone = "9878757654" });
            customers.Add(new Customer() { Name = "Awesome customer", Address = "France", Telephone = "34546456" });
            return Ok<IList<Customer>>(customers);
        }

        //[AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Anonymous()
        {
            IList<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Anonymous customer", Address = "USA", Telephone = "123345456" });
            return Json<IList<Customer>>(customers);
        }
    }
}

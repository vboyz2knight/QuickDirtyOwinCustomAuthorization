using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApiOwin.Models;

namespace MVC.Controllers
{
    public class ApiCallController : Controller
    {
        // GET: ApiCall
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string key)
        {
            key = key ?? string.Empty;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:25109/customers/Get");
            string headerKey = string.Format("Hieu : {0}", key);

            requestMessage.Headers.Add("x-company-auth", headerKey);
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);

            Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
            HttpResponseMessage httpResponse = httpRequest.Result;
            HttpStatusCode statusCode = httpResponse.StatusCode;

            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("Response status code: {0}", statusCode));

            Debug.WriteLine("Response status code: {0}", statusCode);
            HttpContent responseContent = httpResponse.Content;

            if (responseContent != null)
            {
                Task<String> stringContentsTask = responseContent.ReadAsStringAsync();
                String stringContents = stringContentsTask.Result;
                Debug.WriteLine(stringContents);

                output.AppendLine(stringContents);
            }
            var vm = new ApiCallModel();
            vm.output = output.ToString();

            return View(vm);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http.Results;
using System.Web.Mvc;
using Test_2.Models;

namespace Test_2.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult NewsViewer()
        {
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("http://api.mediastack.com/v1/news?access_key=173b7733c3cc870a43936e87ef5026eb");
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                    var readJob = result.Content.ReadAsStringAsync();
                    readJob.Wait();
                    ViewBag.message = readJob.Result.ToString();
            }
            return View();
        }
    }
}


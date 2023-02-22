using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Test_2.Models;

namespace Test_2.Controllers
{
    public class UniversityController : Controller
    {
        // GET: University
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("http://api.genderize.io/?name=num");
            responseTask.Wait();
            var result = responseTask.Result;
            var readJob = result.Content.ReadAsStringAsync().Result;
            var dt = JsonConvert.DeserializeObject<Unidata>(readJob);
            return View(dt);
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Test_2.Models;

namespace Test_2.Controllers
{
    public class CovidController : Controller
    {
        // GET: Covid
        public ActionResult View1()
        {            
                HttpClient client = new HttpClient();
                var responseTask = client.GetAsync("http://api.genderize.io/?name=num");
                responseTask.Wait();
                //if (responseTask.IsCompleted)
                //{
                    var result = responseTask.Result;
                    var readJob = result.Content.ReadAsStringAsync().Result;
                    var dt = JsonConvert.DeserializeObject<Datum>(readJob);
                //}

            return View(dt);
        }
    }
}
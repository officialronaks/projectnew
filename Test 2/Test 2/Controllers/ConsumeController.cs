using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Test_2.Models
{
    public class ConsumeController : Controller

    {
        // GET: Consume

        HttpClient client = new HttpClient();

       public ActionResult News()
        {
            //List<Articles> list = new List<Articles>();
            client.BaseAddress = new Uri("https://newsapi.org/v2/everything?q=tesla&form=2023-01-16&sortBy=publishedAt&apiKey=aad8c6196867647fa84b2ce695f887951");
            var consume = client.GetAsync("GetArticles");
            var test = consume.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content;
                Console.WriteLine(display);
            }
            return View(test);
        }
    }
}
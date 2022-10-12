using CRUD_OPERATION_MVC.Helper;           //controller
using CRUD_OPERATION_MVC.Models;         //fetch data model class
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;        // JsonConvert
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Net.Http;       //for HttpClient

using System.Threading.Tasks;

namespace CRUD_OPERATION_MVC.Controllers
{
    public class HomeController : Controller
    {

        CustomerAPI API = new CustomerAPI();



        public async Task<IActionResult> Index()
        {
            List<ChampCustomerData> Customer = new List<ChampCustomerData>();
            HttpClient client = API.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Customer");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                Customer = JsonConvert.DeserializeObject<List<ChampCustomerData>>(results);
            }
            return View(Customer);
        }



        public async Task<IActionResult>Details(int Id)
        {
            var Customers = new ChampCustomerData();
            HttpClient client = API.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/Customer/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                Customers = JsonConvert.DeserializeObject<ChampCustomerData>(results);

            }
            return View(Customers);
        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ChampCustomerData Customerr)
        {
            HttpClient client = API.Initial();

            //Http Post
           
            var postTask =  client.PostAsJsonAsync<ChampCustomerData>("api/Customer",Customerr);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit***************************
        //[HttpPatch]
        //public async Task<IActionResult> Edit(int Id)
        //{
        //    var Customers = new ChampCustomerData();
        // HttpClient client = API.Initial();
        //    HttpResponseMessage response = await client.GetAsync($"api/Customer/{Id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var results = response.Content.ReadAsStringAsync().Result;
        //        Customers = JsonConvert.DeserializeObject<ChampCustomerData>(results);

        //    }
        //    return View(Customers);
        //}




    public async Task<IActionResult> Delete(int Id)
        {
            var Customer = new ChampCustomerData();
            HttpClient client = API.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"api/Customer/{Id}");
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

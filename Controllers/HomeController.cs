using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RocketElevatorsCustomerPortal.Models;
using Newtonsoft.Json;


namespace RocketElevatorsCustomerPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult InterventionRequest()
        {
            return View();
        }

        public async Task<IActionResult> Batteries()
        {



            List<Battery> BatteryList = new List<Battery>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://domin-rest.azurewebsites.net/api/customers/claudie@cronin.name/batteries"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    BatteryList = JsonConvert.DeserializeObject<List<Battery>>(apiResponse);
                }
            }
            return View(BatteryList);
        }

        public async Task<IActionResult> Columns()
        {



            List<Column> ColumnList = new List<Column>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://domin-rest.azurewebsites.net/api/customers/claudie@cronin.name/columns"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ColumnList = JsonConvert.DeserializeObject<List<Column>>(apiResponse);
                }
            }
            return View(ColumnList);
        }


       public async Task<IActionResult> Elevators()
        {

            List<Elevator> ElevatorList = new List<Elevator>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://domin-rest.azurewebsites.net/api/customers/claudie@cronin.name/elevators"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ElevatorList = JsonConvert.DeserializeObject<List<Elevator>>(apiResponse);
                }
            }
            return View(ElevatorList);
        }

        public async Task<IActionResult> UpdateProfile()
        {
            Customer customer = new Customer();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://domin-rest.azurewebsites.net/api/customers/claudie@cronin.name/info/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return View(customer);
        }

         
        
    


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


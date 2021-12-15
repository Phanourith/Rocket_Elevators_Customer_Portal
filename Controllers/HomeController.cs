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
        private readonly UserManager<IdentityUser> _userManager;
        

        

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Console.WriteLine(user);
            List<Battery> BatteryList = new List<Battery>();
            var email = user.UserName;
            

            using (var httpClient = new HttpClient())
            {
            
                using (var response = await httpClient.GetAsync($"https://domin-rest.azurewebsites.net/api/customers/{email}/batteries"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    BatteryList = JsonConvert.DeserializeObject<List<Battery>>(apiResponse);
                }
            }
            return View(BatteryList);
        }

        public async Task<IActionResult> Columns()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            Console.WriteLine(user);
            List<Battery> BatteryList = new List<Battery>();
            var email = user.UserName;

            List<Column> ColumnList = new List<Column>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://domin-rest.azurewebsites.net/api/customers/{email}/columns"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ColumnList = JsonConvert.DeserializeObject<List<Column>>(apiResponse);
                }
            }
            return View(ColumnList);
        }


       public async Task<IActionResult> Elevators()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Console.WriteLine(user);
            List<Battery> BatteryList = new List<Battery>();
            var email = user.UserName;


            List<Elevator> ElevatorList = new List<Elevator>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://domin-rest.azurewebsites.net/api/customers/{email}/elevators"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ElevatorList = JsonConvert.DeserializeObject<List<Elevator>>(apiResponse);
                }
            }
            return View(ElevatorList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

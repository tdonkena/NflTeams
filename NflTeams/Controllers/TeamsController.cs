using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Entities;
using Newtonsoft.Json;

namespace NflTeams.Controllers
{
    public class TeamsController : Controller
    {       

        public async Task<ActionResult> Index()
        {
            List<Division> Divisions = new List<Division>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Teams");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TeamsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Divisions = JsonConvert.DeserializeObject<List<Division>>(TeamsResponse);

                }
                //returning the employee list to view  
                return View(Divisions);
            }
        }

        public async Task<ActionResult>  Details(string divisionName)
            {                
                Division division = new Division();

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync($"api/Division/{divisionName}");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var TeamsResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        division = JsonConvert.DeserializeObject<Division>(TeamsResponse);

                    }
                    //returning the employee list to view  
                    return View(division);
                }
                
            }
        }
}

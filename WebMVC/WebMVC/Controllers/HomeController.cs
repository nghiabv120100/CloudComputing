using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly IHttpClientFactory _clientFactory;
        private int orderBy = 0;

        public IEnumerable<StudentModel> students { get; set; }

        public HomeController(IHttpClientFactory _clientFactory)
        {
            this._clientFactory = _clientFactory;
        }
        public async Task<IActionResult> Index(int orderBy = 0)
        {
            this.orderBy = orderBy;
            var request = new HttpRequestMessage(HttpMethod.Get,
                "http://localhost:8080/student/getAll");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                students = await JsonSerializer.DeserializeAsync<IEnumerable<StudentModel>>(responseStream);
                /*                if (this.orderBy == 1)
                                {
                                    students = students.OrderByDescending(st => (st.listenning + st.writing, st.reading, st.speaking));
                                }
                                else if (this.orderBy == 2)
                                {
                                    students = students.OrderByDescending(st => (st.year, st.listenning + st.writing, st.reading, st.speaking));
                                }*/

            }
            else
            {
                students = new List<StudentModel>();

            }

            return View(students);
        }

        public async Task<ActionResult> GetEditStudent(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
             "http://localhost:8080/student/getById/" + id);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);
            var itemStudent = new StudentModel();
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                itemStudent = await System.Text.Json.JsonSerializer.DeserializeAsync<StudentModel>(responseStream);
            }
            else
            {
                itemStudent = new StudentModel();
            }


            return View(itemStudent);
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

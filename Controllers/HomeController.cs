using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResturangsystemMVC.Models;
using System.Diagnostics;

namespace ResturangsystemMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7256/";

        public HomeController(ILogger<HomeController> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            
            var response = await _client.GetAsync(baseUri + "getAllMeny");

            var json = await response.Content.ReadAsStringAsync();

            var menyList = JsonConvert.DeserializeObject<List<Meny>>(json);


            return View(menyList);
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

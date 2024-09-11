using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResturangsystemMVC.Models;

namespace ResturangsystemMVC.Controllers
{
    public class MenyController : Controller
    {
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7256/";

        public MenyController(HttpClient client)
        {
            _client = client;
        }


        public async  Task<IActionResult> Index()
        {
            var response = await _client.GetAsync(baseUri + "getAllMeny");

            var json = await response.Content.ReadAsStringAsync();

            var menyList = JsonConvert.DeserializeObject<List<Meny>>(json);



            return View(menyList);
        }
    }
}

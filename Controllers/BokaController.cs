using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResturangsystemMVC.Models;
using ResturangsystemMVC.Models.DTO;
using ResturangsystemMVC.Models.ViewModels;
using System.Text;

namespace ResturangsystemMVC.Controllers
{
    public class BokaController : Controller
    {
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7256/";

        public BokaController(HttpClient client)
        {
            _client = client;
        }


        public IActionResult Index()
        {
            ViewData["Message"] = "Boka bord";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(BokaBord bokaBord)
        {
            if (ModelState.IsValid)
            {
                var dto = new BokaBordDTO
                {
                    Antal = bokaBord.Antal,
                    Datum = bokaBord.Datum,
                    
                };

                var json = JsonConvert.SerializeObject(dto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(baseUri + "getAvailableBords", data);

                var responseTables = await response.Content.ReadAsStringAsync();
                
                var availbeTables = JsonConvert.DeserializeObject<List<AvailableTablesDTO>>(responseTables);

                var viewModel = new SeeBordViewModel
                {
                    BokaBord = bokaBord,
                    AvailableTables = availbeTables
                };

                if (response.IsSuccessStatusCode)
                {

                    TempData["SeeBordViewModel"] = JsonConvert.SerializeObject(viewModel);
                    return RedirectToAction("SeeBord");

                }
            }
            return View(bokaBord);
        }


        public IActionResult SeeBord()
        {
            

            if (TempData["SeeBordViewModel"] != null)
            {
               
                var viewModel = JsonConvert.DeserializeObject<SeeBordViewModel>(TempData["SeeBordViewModel"].ToString());
                
                if(viewModel.AvailableTables.Count == 0)
                {
                    ViewData["Message"] = "No Available tables!";
                }
                else
                {
                    ViewData["Message"] = "Availble tables for your date";
                }
                
                
                return View(viewModel);
            }
           

            return View(new SeeBordViewModel());
           
        }



        [HttpPost]
        public async Task<IActionResult> BokaValdBord(CreateABokningDTO bokning)
        {
            if (ModelState.IsValid)
            {
                              
                
                var json = JsonConvert.SerializeObject(bokning);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(baseUri + "add", data);

                if (response.IsSuccessStatusCode)
                {
                    return View(bokning);

                }
                return View(bokning);

            }
            return View(bokning);
        }




    }
}

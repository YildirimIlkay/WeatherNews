using Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService ws;

        public HomeController(ILogger<HomeController> logger,IWeatherService ws)
        {
            _logger = logger;
            this.ws = ws;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Index(HomeViewModel vm)
        {
            if (ModelState.IsValid)
            {

                //vm.Temperature = new MgmService().GetTemperature(vm.Place);
                //vm.Temperature = new WeatherComService().GetWeather(vm.Place);
                // Her seferinde kod değiştirmek yerine interface kullanmak daha mantıklı
                //Program.cs e Service Eklenir ve değişiklikler program.cs üzerinden yapılır
                vm.Temperature = ws.Temperature(vm.Place);

                
            }
            return View(vm);
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
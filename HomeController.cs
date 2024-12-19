using System.Diagnostics;
using KadinErkekKuafor.Models;
using Microsoft.AspNetCore.Mvc;

namespace KadinErkekKuafor.Controllers
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

        public IActionResult PriceList()
        {
            var prices = new List<Price>
    {
        new Price { Name = "VIP Paket", Category = "Damat", PriceValue = "4000 TL" },
        new Price { Name = "Damat", Category = "Damat", PriceValue = "2000 TL" },
        new Price { Name = "Manikür", Category = "Manikür & Pedikür", PriceValue = "400 TL" },
        // Diğer fiyatları buraya ekleyebilirsiniz
    };

            return View(prices);
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
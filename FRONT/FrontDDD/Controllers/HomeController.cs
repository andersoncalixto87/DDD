using FrontDDD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDDD.Controllers
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
            DateTime tokenData = new DateTime(1900, 04, 30, 0, 0, 0);
            var token = HttpContext.Session.GetString("token");
            string Data = HttpContext.Session.GetString("tokenData");
            if (Data != null)
                tokenData = DateTime.Parse(Data);
            if (token == null || DateTime.UtcNow > tokenData)
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

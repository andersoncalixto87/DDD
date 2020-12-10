using FrontDDD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontDDD.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            if (user == null)
            {
                return StatusCode(400);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                
                //HTTP POST
                var postTask = client.PostAsJsonAsync<UserViewModel>("user/login", user);
                postTask.Wait();
                var result = postTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var token = readTask.Result;
                    JObject json = JObject.Parse(token);
                    string strToken = (string)json["token"];
                    HttpContext.Session.SetString("token", strToken);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(user);
        }
    }
}

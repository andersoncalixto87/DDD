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
    public class UsuarioController : Controller
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
                var postTask = client.PostAsJsonAsync<UserViewModel>("usuario/login", user);
                postTask.Wait();
                var result = postTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var token = readTask.Result;
                    var Date = DateTime.UtcNow.AddHours(2);
                    JObject json = JObject.Parse(token);
                    string strToken = (string)json["token"];
                    JObject jsonUser = JObject.Parse(json["user"].ToString());
                    HttpContext.Session.SetString("token", strToken);
                    HttpContext.Session.SetString("user", jsonUser.ToString());
                    HttpContext.Session.SetString("tokenData", Date.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(user);
        }


        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(UserViewModel usuario)
        {
            if (usuario == null)
            {
                return StatusCode(400);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
               

                //HTTP POST
                var postTask = client.PostAsJsonAsync<UserViewModel>("usuario", usuario);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(usuario);
        }
    }
}

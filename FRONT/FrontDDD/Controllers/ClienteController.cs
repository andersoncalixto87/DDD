using FrontDDD.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace FrontDDD.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ClienteViewModel> clientes = null;

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //HTTP GET
                var responseTask = client.GetAsync("cliente");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ClienteViewModel>>();
                    readTask.Wait();

                    clientes = readTask.Result;
                }
                else
                {
                    clientes = Enumerable.Empty<ClienteViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(clientes);
            }
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(ClienteViewModel cliente)
        {
            if (cliente == null)
            {
                return StatusCode(400);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ClienteViewModel>("cliente", cliente);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(cliente);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }

            ClienteViewModel cliente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //HTTP GET
                var responseTask = client.GetAsync("cliente/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClienteViewModel>();
                    readTask.Wait();

                    cliente = readTask.Result;
                }
            }

            return View(cliente);
        }
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (cliente == null)
            {
                return StatusCode(400);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<ClienteViewModel>("cliente", cliente);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }

            ClienteViewModel cliente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                //HTTP DELETE
                var deleteTask = client.DeleteAsync("cliente/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

    
    
    }   
}

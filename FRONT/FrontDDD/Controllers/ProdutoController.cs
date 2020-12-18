using FrontDDD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FrontDDD.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ProdutoViewModel> produtos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //HTTP GET
                var responseTask = client.GetAsync("produto");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProdutoViewModel>>();
                    readTask.Wait();

                    produtos = readTask.Result;
                }
                else
                {
                    produtos = Enumerable.Empty<ProdutoViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(produtos);
            }
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(ProdutoViewModel produto)
        {
            if (produto == null)
            {
                return StatusCode(400);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ProdutoViewModel>("produto", produto);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(produto);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }

            ProdutoViewModel produto = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //HTTP GET
                var responseTask = client.GetAsync("produto/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProdutoViewModel>();
                    readTask.Wait();

                    produto = readTask.Result;
                }
            }

            return View(produto);
        }
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (produto == null)
            {
                return StatusCode(400);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/");
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<ProdutoViewModel>("produto", produto);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(produto);
        }

    }
}

using APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_APIs.Controllers
{
    public class SuppliersController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44345/API/")
        };
        // GET: Suppliers
        public ActionResult Index()
        {

            IEnumerable<Supplier> supplierList = null;
            var responseTask = client.GetAsync("Suppliers");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplierList = readTask.Result;
            }
            return View(supplierList);
        }

        // CREATE : Suppliers
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Suppliers", supplier).Result;
            return RedirectToAction("Index");
        }
        // EDIT : Supplier
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            var put = client.PutAsJsonAsync<Supplier>("Suppliers/" + supplier.Id, supplier);
            put.Wait();
            return RedirectToAction("Index");
        }
        // DELETE : Supplier
        public ActionResult Delete(int Id)
        {
            IEnumerable<Supplier> supplier = null;
            var responseTask = client.GetAsync("Suppliers/" + Id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result;
            }
            return View(supplier.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(Supplier supplier, int Id)
        {

            var delete = client.DeleteAsync("Suppliers/" + Id.ToString());
            delete.Wait();
            var result = delete.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        // DETAILS : Supplier
        public ActionResult Details(int Id)
        {
            IEnumerable<Supplier> supplier = null;
            var responseTask = client.GetAsync("Suppliers/" + Id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result;
            }
            return View(supplier.FirstOrDefault(s => s.Id == Id));
        }
    }
}
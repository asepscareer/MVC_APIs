using APIs.Context;
using APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_APIs.Controllers
{
    public class ItemsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44345/API/")
        };
        // GET: Item
        public ActionResult Index()
        {

            IEnumerable<ViewItem> itemList = null;
            var responseTask = client.GetAsync("Items");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ViewItem>>();
                readTask.Wait();
                itemList = readTask.Result;
            }
            return View(itemList);
        }

        // CREATE : Item
        public ActionResult Create()
        {
            IEnumerable<Supplier> suppliers = null;
            var responseTask = client.GetAsync("Items");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            ViewBag.SupplierID = new SelectList(suppliers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Items", item).Result;
            return RedirectToAction("Index");
        }
        // EDIT : Item
        public ActionResult Edit(int Id)
        {
            IEnumerable<Supplier> suppliers = null;
            var responseTask = client.GetAsync("Items");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            ViewBag.SupplierID = new SelectList(suppliers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            var put = client.PutAsJsonAsync<Item>("Items/" + item.Id, item);
            put.Wait();
            return RedirectToAction("Index");
        }
        // DELETE : Supplier
        public ActionResult Delete(int Id)
        {
            IEnumerable<Item> item = null;
            var responseTask = client.GetAsync("Items/" + Id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Item>>();
                readTask.Wait();
                item = readTask.Result;
            }
            return View(item.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(Item item, int Id)
        {

            var delete = client.DeleteAsync("Items/" + Id.ToString());
            delete.Wait();
            var result = delete.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        // DETAILS : Item
        public ActionResult Details(int Id)
        {
            IEnumerable<ViewItem> viewItem = null;
            var responseTask = client.GetAsync("Items/" + Id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ViewItem>>();
                readTask.Wait();
                viewItem = readTask.Result;
            }
            return View(viewItem.FirstOrDefault(s => s.Id == Id));
        }
    }
}